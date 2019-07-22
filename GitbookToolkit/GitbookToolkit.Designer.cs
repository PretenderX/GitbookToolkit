namespace GitbookToolkit
{
    partial class GitbookToolkit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GitbookToolkit));
            this.label1 = new System.Windows.Forms.Label();
            this.bookFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtBookRootPath = new System.Windows.Forms.TextBox();
            this.btnSelectBookRootPath = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.psLog = new System.Windows.Forms.RichTextBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.buildTypes = new System.Windows.Forms.CheckedListBox();
            this.psBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.displayFullLogToggle = new System.Windows.Forms.CheckBox();
            this.btnStartPreview = new System.Windows.Forms.Button();
            this.btnOpenPreview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book 根目录";
            // 
            // txtBookRootPath
            // 
            this.txtBookRootPath.Location = new System.Drawing.Point(116, 15);
            this.txtBookRootPath.Name = "txtBookRootPath";
            this.txtBookRootPath.Size = new System.Drawing.Size(458, 22);
            this.txtBookRootPath.TabIndex = 1;
            this.txtBookRootPath.Text = "C:\\GitRepositories\\GitbookTemplate\\Book";
            // 
            // btnSelectBookRootPath
            // 
            this.btnSelectBookRootPath.Location = new System.Drawing.Point(580, 10);
            this.btnSelectBookRootPath.Name = "btnSelectBookRootPath";
            this.btnSelectBookRootPath.Size = new System.Drawing.Size(108, 33);
            this.btnSelectBookRootPath.TabIndex = 2;
            this.btnSelectBookRootPath.Text = "选择...";
            this.btnSelectBookRootPath.UseVisualStyleBackColor = true;
            this.btnSelectBookRootPath.Click += new System.EventHandler(this.btnSelectBookRootPath_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(116, 59);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(108, 33);
            this.btnInstall.TabIndex = 3;
            this.btnInstall.Text = "初始化";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Gitbook命令";
            // 
            // psLog
            // 
            this.psLog.BackColor = System.Drawing.SystemColors.WindowText;
            this.psLog.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.psLog.ForeColor = System.Drawing.Color.Lime;
            this.psLog.Location = new System.Drawing.Point(14, 155);
            this.psLog.Name = "psLog";
            this.psLog.Size = new System.Drawing.Size(674, 427);
            this.psLog.TabIndex = 7;
            this.psLog.Text = "";
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(580, 59);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(108, 33);
            this.btnBuild.TabIndex = 6;
            this.btnBuild.Text = "生成";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // buildTypes
            // 
            this.buildTypes.FormattingEnabled = true;
            this.buildTypes.Items.AddRange(new object[] {
            "PDF",
            "EPUB",
            "MOBI",
            "HTML"});
            this.buildTypes.Location = new System.Drawing.Point(498, 59);
            this.buildTypes.Name = "buildTypes";
            this.buildTypes.Size = new System.Drawing.Size(76, 89);
            this.buildTypes.TabIndex = 5;
            // 
            // psBackgroundWorker
            // 
            this.psBackgroundWorker.WorkerReportsProgress = true;
            this.psBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.psBackgroundWorker_DoWork);
            this.psBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.psBackgroundWorker_ProgressChanged);
            this.psBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.psBackgroundWorker_RunWorkerCompleted);
            // 
            // displayFullLogToggle
            // 
            this.displayFullLogToggle.AutoSize = true;
            this.displayFullLogToggle.Location = new System.Drawing.Point(14, 128);
            this.displayFullLogToggle.Name = "displayFullLogToggle";
            this.displayFullLogToggle.Size = new System.Drawing.Size(114, 21);
            this.displayFullLogToggle.TabIndex = 14;
            this.displayFullLogToggle.Text = "显示详细日志";
            this.displayFullLogToggle.UseVisualStyleBackColor = true;
            // 
            // btnStartPreview
            // 
            this.btnStartPreview.Location = new System.Drawing.Point(245, 59);
            this.btnStartPreview.Name = "btnStartPreview";
            this.btnStartPreview.Size = new System.Drawing.Size(108, 33);
            this.btnStartPreview.TabIndex = 15;
            this.btnStartPreview.Text = "启动预览";
            this.btnStartPreview.UseVisualStyleBackColor = true;
            this.btnStartPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnOpenPreview
            // 
            this.btnOpenPreview.Location = new System.Drawing.Point(372, 59);
            this.btnOpenPreview.Name = "btnOpenPreview";
            this.btnOpenPreview.Size = new System.Drawing.Size(108, 33);
            this.btnOpenPreview.TabIndex = 16;
            this.btnOpenPreview.Text = "打开预览";
            this.btnOpenPreview.UseVisualStyleBackColor = true;
            this.btnOpenPreview.Click += new System.EventHandler(this.btnOpenPreview_Click);
            // 
            // GitbookToolkit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 594);
            this.Controls.Add(this.btnOpenPreview);
            this.Controls.Add(this.btnStartPreview);
            this.Controls.Add(this.displayFullLogToggle);
            this.Controls.Add(this.buildTypes);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.psLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnSelectBookRootPath);
            this.Controls.Add(this.txtBookRootPath);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(720, 641);
            this.MinimumSize = new System.Drawing.Size(720, 641);
            this.Name = "GitbookToolkit";
            this.Text = "Gitbook Toolkit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog bookFolderBrowserDialog;
        private System.Windows.Forms.TextBox txtBookRootPath;
        private System.Windows.Forms.Button btnSelectBookRootPath;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox psLog;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.CheckedListBox buildTypes;
        private System.ComponentModel.BackgroundWorker psBackgroundWorker;
        private System.Windows.Forms.CheckBox displayFullLogToggle;
        private System.Windows.Forms.Button btnStartPreview;
        private System.Windows.Forms.Button btnOpenPreview;
    }
}

