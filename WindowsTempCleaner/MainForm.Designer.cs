using System.Windows.Forms;

namespace WindowsTempCleaner
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cbWindowsTemp = new System.Windows.Forms.CheckBox();
            this.cbUserTemp = new System.Windows.Forms.CheckBox();
            this.cbLocalAppDataTemp = new System.Windows.Forms.CheckBox();
            this.numericDays = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.columnPath = new System.Windows.Forms.ColumnHeader();
            this.columnSize = new System.Windows.Forms.ColumnHeader();
            this.columnDate = new System.Windows.Forms.ColumnHeader();
            this.lblFound = new System.Windows.Forms.Label();
            this.txtExclude = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbToRecycle = new System.Windows.Forms.CheckBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericDays)).BeginInit();
            this.SuspendLayout();
            //
            // cbWindowsTemp
            //
            this.cbWindowsTemp.AutoSize = true;
            this.cbWindowsTemp.Location = new System.Drawing.Point(12, 12);
            this.cbWindowsTemp.Name = "cbWindowsTemp";
            this.cbWindowsTemp.Size = new System.Drawing.Size(120, 19);
            this.cbWindowsTemp.TabIndex = 0;
            this.cbWindowsTemp.Text = "Windows\\Temp";
            this.cbWindowsTemp.UseVisualStyleBackColor = true;
            //
            // cbUserTemp
            //
            this.cbUserTemp.AutoSize = true;
            this.cbUserTemp.Location = new System.Drawing.Point(12, 37);
            this.cbUserTemp.Name = "cbUserTemp";
            this.cbUserTemp.Size = new System.Drawing.Size(180, 19);
            this.cbUserTemp.TabIndex = 1;
            this.cbUserTemp.Text = "User Temp (GetTempPath)";
            this.cbUserTemp.UseVisualStyleBackColor = true;
            //
            // cbLocalAppDataTemp
            //
            this.cbLocalAppDataTemp.AutoSize = true;
            this.cbLocalAppDataTemp.Location = new System.Drawing.Point(12, 62);
            this.cbLocalAppDataTemp.Name = "cbLocalAppDataTemp";
            this.cbLocalAppDataTemp.Size = new System.Drawing.Size(150, 19);
            this.cbLocalAppDataTemp.TabIndex = 2;
            this.cbLocalAppDataTemp.Text = "LocalAppData\\Temp";
            this.cbLocalAppDataTemp.UseVisualStyleBackColor = true;
            //
            // numericDays
            //
            this.numericDays.Location = new System.Drawing.Point(12, 112);
            this.numericDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            this.numericDays.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numericDays.Name = "numericDays";
            this.numericDays.Size = new System.Drawing.Size(60, 23);
            this.numericDays.TabIndex = 3;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Delete files older than (days)";
            //
            // btnPreview
            //
            this.btnPreview.Location = new System.Drawing.Point(12, 150);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 30);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            //
            // btnClean
            //
            this.btnClean.Location = new System.Drawing.Point(118, 150);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(100, 30);
            this.btnClean.TabIndex = 6;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            //
            // listViewFiles
            //
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnPath, this.columnSize, this.columnDate });
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.HideSelection = false;
            this.listViewFiles.Location = new System.Drawing.Point(12, 200);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(760, 250);
            this.listViewFiles.TabIndex = 7;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            //
            // columnPath
            //
            this.columnPath.Text = "Path";
            this.columnPath.Width = 520;
            //
            // columnSize
            //
            this.columnSize.Text = "Size";
            this.columnSize.Width = 100;
            //
            // columnDate
            //
            this.columnDate.Text = "Last Write";
            this.columnDate.Width = 140;
            //
            // lblFound
            //
            this.lblFound.AutoSize = true;
            this.lblFound.Location = new System.Drawing.Point(12, 470);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(53, 15);
            this.lblFound.TabIndex = 8;
            this.lblFound.Text = "Files: 0";
            //
            // txtExclude
            //
            this.txtExclude.Location = new System.Drawing.Point(12, 86);
            this.txtExclude.Name = "txtExclude";
            this.txtExclude.Size = new System.Drawing.Size(760, 23);
            this.txtExclude.TabIndex = 9;
            this.txtExclude.PlaceholderText = "Exclude extensions/keywords, comma-separated (e.g. .exe,.dll,System)";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Exclusions";
            //
            // cbToRecycle
            //
            this.cbToRecycle.AutoSize = true;
            this.cbToRecycle.Location = new System.Drawing.Point(12, 127);
            this.cbToRecycle.Name = "cbToRecycle";
            this.cbToRecycle.Size = new System.Drawing.Size(155, 19);
            this.cbToRecycle.TabIndex = 11;
            this.cbToRecycle.Text = "Send to Recycle Bin";
            this.cbToRecycle.UseVisualStyleBackColor = true;
            //
            // txtLog
            //
            this.txtLog.Location = new System.Drawing.Point(778, 12);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(400, 470);
            this.txtLog.TabIndex = 12;
            this.txtLog.Text = "";
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 500);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 15);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Status";
            //
            // btnRefresh
            //
            this.btnRefresh.Location = new System.Drawing.Point(224, 150);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Reset";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // btnOpenFolder
            //
            this.btnOpenFolder.Location = new System.Drawing.Point(310, 150);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(140, 30);
            this.btnOpenFolder.TabIndex = 15;
            this.btnOpenFolder.Text = "Open Selected Folders";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            //
            // MainForm
            //
            this.ClientSize = new System.Drawing.Size(1190, 540);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.cbToRecycle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtExclude);
            this.Controls.Add(this.lblFound);
            this.Controls.Add(this.listViewFiles);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericDays);
            this.Controls.Add(this.cbLocalAppDataTemp);
            this.Controls.Add(this.cbUserTemp);
            this.Controls.Add(this.cbWindowsTemp);
            this.Name = "MainForm";
            this.Text = "Windows Temp Cleaner";
            ((System.ComponentModel.ISupportInitialize)(this.numericDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox cbWindowsTemp;
        private System.Windows.Forms.CheckBox cbUserTemp;
        private System.Windows.Forms.CheckBox cbLocalAppDataTemp;
        private System.Windows.Forms.NumericUpDown numericDays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.ColumnHeader columnPath;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.ColumnHeader columnDate;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.TextBox txtExclude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbToRecycle;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnOpenFolder;
    }
}