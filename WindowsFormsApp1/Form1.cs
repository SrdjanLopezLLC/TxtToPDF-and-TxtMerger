using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Updated 2025-11-04 by SL

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (txtOutputFolder != null)
                txtOutputFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (lstFiles != null)
            {
                lstFiles.AllowDrop = true;
                lstFiles.DragEnter += lstFiles_DragEnter;
                lstFiles.DragDrop += lstFiles_DragDrop;

                lstFiles.DoubleClick += (s, a) =>
                {
                    var p = lstFiles.SelectedItem as string;
                    if (!string.IsNullOrEmpty(p) && File.Exists(p))
                    {
                        try { System.Diagnostics.Process.Start("explorer.exe", "/select,\"" + p + "\""); } catch { }
                    }
                };
            }

            UpdateStatus();
        }

        private async Task RunWithProgressAsync(Func<IProgress<int>, Task> action)
        {
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Continuous;
            var progress = new Progress<int>(v =>
            {
                progressBar1.Value = Math.Min(progressBar1.Maximum, v);
            });
            await Task.Run(() => action(progress));
            progressBar1.Value = progressBar1.Maximum;
        }

        private void UpdateStatus(string message)
        {
            try
            {
                var statusStrip = this.Controls.OfType<StatusStrip>().FirstOrDefault();
                if (statusStrip != null)
                {
                    var label = statusStrip.Items.OfType<ToolStripStatusLabel>().FirstOrDefault();
                    if (label != null)
                    {
                        label.Text = string.IsNullOrEmpty(message)
                            ? "Files in list: " + (lstFiles != null ? lstFiles.Items.Count : 0)
                            : message;
                        return;
                    }
                }
            }
            catch { }
            this.Text = string.IsNullOrEmpty(message)
                ? "TXT Tools By SL - Files: " + (lstFiles != null ? lstFiles.Items.Count : 0)
                : message;
        }
        private void UpdateStatus() { UpdateStatus(null); }

        private IEnumerable<string> GetTextFiles()
        {
            if (lstFiles == null) return Enumerable.Empty<string>();
            return lstFiles.Items.Cast<object>()
                .Select(o => o as string)
                .Where(p => !string.IsNullOrEmpty(p) && File.Exists(p));
        }

        private bool EnsureAnyFiles()
        {
            if (!GetTextFiles().Any())
            {
                MessageBox.Show(this, "Please add at least one .txt file.", "Nothing to do",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private string ChooseSavePath(string defaultFileName, string filter)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = (txtOutputFolder != null && Directory.Exists(txtOutputFolder.Text))
                    ? txtOutputFolder.Text
                    : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                sfd.FileName = defaultFileName;
                sfd.Filter = filter;
                sfd.OverwritePrompt = true;
                sfd.AddExtension = true;

                if (sfd.ShowDialog(this) == DialogResult.OK)
                    return sfd.FileName;
            }
            return null;
        }

        private void MoveSelected(int delta)
        {
            if (lstFiles == null) return;

            var indices = lstFiles.SelectedIndices.Cast<int>().OrderBy(i => i).ToList();
            if (delta > 0) indices.Reverse();

            foreach (var i in indices)
            {
                int newIndex = i + delta;
                if (newIndex < 0 || newIndex >= lstFiles.Items.Count) continue;
                var item = lstFiles.Items[i];
                lstFiles.Items.RemoveAt(i);
                lstFiles.Items.Insert(newIndex, item);
                lstFiles.SetSelected(newIndex, true);
            }
            UpdateStatus("Reordered.");
        }

        private async Task MergeTxtFilesAsync(IEnumerable<string> files, string outputPath, bool insertFilenameSeparators, IProgress<int> progress = null)
        {
            var fileList = files.ToList();
            int total = fileList.Count;
            if (total == 0) return;

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            using (var writer = new StreamWriter(outputPath, false, new UTF8Encoding(false), 65536)) // large buffer
            {
                bool first = true;
                //int index = 0;

                await Task.Run(() =>
                {
                    Parallel.ForEach(fileList, (file, state, i) =>
                    {
                        if (!File.Exists(file)) return;
                        var lines = File.ReadLines(file, Encoding.UTF8).ToList();
                        lock (writer)
                        {
                            if (!first && insertFilenameSeparators)
                            {
                                writer.WriteLine();
                                writer.WriteLine(new string('-', 80));
                                writer.WriteLine($"File: {Path.GetFileName(file)} ({file})");
                                writer.WriteLine(new string('-', 80));
                                writer.WriteLine();
                            }
                            first = false;

                            foreach (var line in lines)
                                writer.WriteLine(line);
                        }
                        progress?.Report((int)((i + 1) / (double)total * 100));
                    });
                });
            }
        }

        private void lstFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var paths = (string[])e.Data.GetData(DataFormats.FileDrop);
                bool ok = paths.Any(p =>
                    Path.GetExtension(p).Equals(".txt", StringComparison.OrdinalIgnoreCase) ||
                    Directory.Exists(p));
                e.Effect = ok ? DragDropEffects.Copy : DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lstFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (lstFiles == null) return;

            var paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var p in paths)
            {
                if (Directory.Exists(p))
                {
                    foreach (var tf in Directory.EnumerateFiles(p, "*.txt", SearchOption.AllDirectories))
                        if (!lstFiles.Items.Contains(tf)) lstFiles.Items.Add(tf);
                }
                else if (Path.GetExtension(p).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    if (!lstFiles.Items.Contains(p)) lstFiles.Items.Add(p);
                }
            }
            UpdateStatus("Added via drag & drop.");
        }

        // Core: TXT to PDF (PDFsharp 6.x safe) 
        private async Task ConvertTxtToPdfAsync(string sourceTxtPath, string pdfPath, int margin, int fontSize, bool addPageNumbers, IProgress<int> progress)
        {
            await Task.Run(() =>
            {
                var lines = File.ReadAllLines(sourceTxtPath, Encoding.UTF8);
                int totalLines = lines.Length;
                if (totalLines == 0) return;

                using (var document = new PdfDocument())
                {
                    document.Info.Title = Path.GetFileName(sourceTxtPath);
                    document.Info.Author = Environment.UserName;

                    XFont bodyFont = new XFont("Consolas", fontSize, XFontStyleEx.Regular);
                    XFont footerFont = new XFont("Segoe UI", 9, XFontStyleEx.Regular);

                    XUnit pageWidth = XUnit.FromMillimeter(210);
                    XUnit pageHeight = XUnit.FromMillimeter(297);
                    double left = margin, right = margin, top = margin, bottom = margin;
                    double contentWidth = pageWidth.Point - left - right;

                    PdfPage page = document.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    double y = top;
                    double lineHeight = gfx.MeasureString("Ay", bodyFont).Height * 1.25;
                    int pageNum = 1;

                    foreach (var (line, idx) in lines.Select((v, i) => (v, i)))
                    {
                        string txt = line.Replace("\t", "    ");
                        if (y + lineHeight > pageHeight.Point - bottom)
                        {
                            if (addPageNumbers)
                                DrawPageNumber(gfx, footerFont, pageNum++, document);
                            page = document.AddPage();
                            gfx = XGraphics.FromPdfPage(page);
                            y = top;
                        }

                        gfx.DrawString(txt, bodyFont, XBrushes.Black,
                            new XRect(left, y, contentWidth, lineHeight), XStringFormats.TopLeft);
                        y += lineHeight;

                        if (idx % 50 == 0)
                            progress?.Report((int)((idx + 1) / (double)totalLines * 100));
                    }

                    if (addPageNumbers)
                        DrawPageNumber(gfx, footerFont, pageNum, document);

                    document.Save(pdfPath);
                }
            });
        }

        private void DrawPageNumber(XGraphics gfx, XFont footerFont, int currentPageNumber, PdfDocument doc)
        {
            string text = "Page " + currentPageNumber + " of " + doc.PageCount;
            XSize size = gfx.MeasureString(text, footerFont);

            double y = gfx.PageSize.Height - 40;
            double x = (gfx.PageSize.Width - size.Width) / 2.0;

            gfx.DrawString(text, footerFont, XBrushes.Gray, new XPoint(x, y));
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Add .txt files";
                ofd.Filter = "Text files (*.txt)|*.txt";
                ofd.Multiselect = true;

                if (ofd.ShowDialog(this) == DialogResult.OK && lstFiles != null)
                {
                    foreach (var f in ofd.FileNames)
                    {
                        if (Path.GetExtension(f).Equals(".txt", StringComparison.OrdinalIgnoreCase) &&
                            !lstFiles.Items.Contains(f))
                            lstFiles.Items.Add(f);
                    }
                    UpdateStatus("Added files.");
                }
            }
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (lstFiles == null) return;
            var sel = lstFiles.SelectedItems.Cast<object>().ToList();
            foreach (var item in sel) lstFiles.Items.Remove(item);
            UpdateStatus("Removed selected.");
        }

        private void btnMoveUp_Click(object sender, EventArgs e) { MoveSelected(-1); }
        private void btnMoveDown_Click(object sender, EventArgs e) { MoveSelected(+1); }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lstFiles != null) lstFiles.Items.Clear();
            UpdateStatus("Cleared list.");
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (txtOutputFolder != null && Directory.Exists(txtOutputFolder.Text))
                    fbd.SelectedPath = txtOutputFolder.Text;

                if (fbd.ShowDialog(this) == DialogResult.OK && txtOutputFolder != null)
                    txtOutputFolder.Text = fbd.SelectedPath;
            }
        }

        private async void btnMergeTxt_Click(object sender, EventArgs e)
        {
            if (!EnsureAnyFiles()) return;
            string savePath = ChooseSavePath("Merged.txt", "Text file (*.txt)|*.txt");
            if (string.IsNullOrWhiteSpace(savePath)) return;

            try
            {
                bool insertSep = chkInsertFilenameSeparator?.Checked ?? true;
                await RunWithProgressAsync(progress =>
                    MergeTxtFilesAsync(GetTextFiles(), savePath, insertSep, progress));
                MessageBox.Show(this, "Merged successfully:\n" + savePath, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to merge:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnConvertToPdf_Click(object sender, EventArgs e)
        {
            if (!EnsureAnyFiles()) return;

            var files = GetTextFiles().ToList();
            string tempCombined = null;

            try
            {
                string sourceTxtPath;
                if (files.Count == 1)
                    sourceTxtPath = files[0];
                else
                {
                    tempCombined = Path.Combine(Path.GetTempPath(), "_merged.txt");
                    bool insertSep = chkInsertFilenameSeparator?.Checked ?? true;
                    await RunWithProgressAsync(progress =>
                        MergeTxtFilesAsync(files, tempCombined, insertSep, progress));
                    sourceTxtPath = tempCombined;
                }

                string defaultPdfName = Path.GetFileNameWithoutExtension(files.Count == 1 ? files[0] : "Merged") + ".pdf";
                string savePdf = ChooseSavePath(defaultPdfName, "PDF file (*.pdf)|*.pdf");
                if (string.IsNullOrWhiteSpace(savePdf)) return;

                int margin = (int)(nudMargin?.Value ?? 72);
                int fontSize = (int)(nudFontSize?.Value ?? 11);
                bool addPageNumbers = chkPageNumbers?.Checked ?? true;

                await RunWithProgressAsync(progress =>
                    ConvertTxtToPdfAsync(sourceTxtPath, savePdf, margin, fontSize, addPageNumbers, progress));

                MessageBox.Show(this, "PDF created:\n" + savePdf, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to create PDF:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!string.IsNullOrEmpty(tempCombined) && File.Exists(tempCombined))
                    File.Delete(tempCombined);
            }
        }

        // Designer-wired no-op handlers (to satisfy InitializeComponent wiring)
        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e) { }
        private void chkInsertFilenameSeparator_CheckedChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void nudFontSize_ValueChanged(object sender, EventArgs e) { }
        private void nudMargin_ValueChanged(object sender, EventArgs e) { }
        private void chkPageNumbers_CheckedChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void txtOutputFolder_TextChanged(object sender, EventArgs e) { }
        private void ToolStripStatusLabel_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
