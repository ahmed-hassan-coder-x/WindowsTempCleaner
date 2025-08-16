using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsTempCleaner
{
    public partial class MainForm : Form
    {
        private readonly Cleaner _cleaner;

        public MainForm()
        {
            InitializeComponent();
            _cleaner = new Cleaner(Log);
            numericDays.Value = 7;
            cbWindowsTemp.Checked = true;
            cbUserTemp.Checked = true;
            cbLocalAppDataTemp.Checked = false;
            UpdateStatus("Ready");
        }

        private void Log(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Log(text)));
                return;
            }
            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {text}{Environment.NewLine}");
        }

        private void UpdateStatus(string s)
        {
            lblStatus.Text = s;
        }

        private string[] SelectedFolders()
        {
            var list = new List<string>();
            if (cbWindowsTemp.Checked) list.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Temp"));
            if (cbUserTemp.Checked) list.Add(Path.GetTempPath());
            if (cbLocalAppDataTemp.Checked) list.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp"));
            return list.ToArray();
        }

        private async void btnPreview_Click(object sender, EventArgs e)
        {
            await RunScan(preview: true);
        }

        private async void btnClean_Click(object sender, EventArgs e)
        {
            await RunScan(preview: false);
        }

        private async Task RunScan(bool preview)
        {
            try
            {
                btnPreview.Enabled = false;
                btnClean.Enabled = false;
                listViewFiles.Items.Clear();
                txtLog.Clear();
                UpdateStatus(preview ? "Previewing..." : "Cleaning...");

                int days = (int)numericDays.Value;
                var folders = SelectedFolders();
                if (folders.Length == 0)
                {
                    MessageBox.Show("Select at least one folder to scan.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var candidates = await Task.Run(() => _cleaner.GetCandidateFiles(folders, days, txtExclude.Text));

                long totalSize = 0;
                foreach (var f in candidates)
                {
                    var fi = new FileInfo(f);
                    var lvi = new ListViewItem(new[] { f, Utils.BytesToReadable(fi.Length), fi.LastWriteTime.ToString() });
                    listViewFiles.Items.Add(lvi);
                    totalSize += fi.Length;
                }

                lblFound.Text = $"Files: {candidates.Count} — Size: {Utils.BytesToReadable(totalSize)}";
                Log($"Found {candidates.Count} candidate files. Total size: {Utils.BytesToReadable(totalSize)}");

                if (candidates.Count == 0)
                {
                    UpdateStatus("No files to delete.");
                    return;
                }

                if (preview)
                {
                    UpdateStatus("Preview ready — nothing deleted.");
                    btnPreview.Enabled = true;
                    btnClean.Enabled = true;
                    return;
                }

                var confirm = MessageBox.Show($"Delete {candidates.Count} files — total {Utils.BytesToReadable(totalSize)}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                {
                    UpdateStatus("Deletion canceled.");
                    btnPreview.Enabled = true;
                    btnClean.Enabled = true;
                    return;
                }

                bool sendToRecycle = cbToRecycle.Checked;
                var result = await Task.Run(() => _cleaner.DeleteFiles(candidates, sendToRecycle));

                Log($"Done: deleted {result.DeletedCount} files — failed {result.FailedCount}.");
                UpdateStatus($"Finished: deleted {result.DeletedCount} files");
            }
            catch (Exception ex)
            {
                Log("Error: " + ex.Message);
                UpdateStatus("An error occurred");
            }
            finally
            {
                btnPreview.Enabled = true;
                btnClean.Enabled = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            listViewFiles.Items.Clear();
            txtLog.Clear();
            lblFound.Text = "Files: 0";
            UpdateStatus("Ready");
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            var folders = SelectedFolders();
            foreach (var f in folders)
            {
                if (Directory.Exists(f))
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() { FileName = f, UseShellExecute = true });
            }
        }
    }
}