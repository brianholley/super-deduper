namespace FileDupeFinder
{
    partial class FileForm
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
            this.lbDuplicateSets = new System.Windows.Forms.ListBox();
            this.duplicatesPanel = new System.Windows.Forms.Panel();
            this.lblPath = new System.Windows.Forms.Label();
            this.tbSearchPath = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbDuplicateSets
            // 
            this.lbDuplicateSets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDuplicateSets.FormattingEnabled = true;
            this.lbDuplicateSets.Location = new System.Drawing.Point(16, 43);
            this.lbDuplicateSets.Name = "lbDuplicateSets";
            this.lbDuplicateSets.Size = new System.Drawing.Size(175, 537);
            this.lbDuplicateSets.TabIndex = 4;
            this.lbDuplicateSets.SelectedIndexChanged += new System.EventHandler(this.lbDuplicateSets_SelectedIndexChanged);
            // 
            // duplicatesPanel
            // 
            this.duplicatesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.duplicatesPanel.AutoScroll = true;
            this.duplicatesPanel.BackColor = System.Drawing.SystemColors.Window;
            this.duplicatesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.duplicatesPanel.Location = new System.Drawing.Point(197, 43);
            this.duplicatesPanel.Name = "duplicatesPanel";
            this.duplicatesPanel.Size = new System.Drawing.Size(680, 508);
            this.duplicatesPanel.TabIndex = 5;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(13, 13);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(66, 13);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Search Path";
            // 
            // tbSearchPath
            // 
            this.tbSearchPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchPath.Location = new System.Drawing.Point(85, 13);
            this.tbSearchPath.Name = "tbSearchPath";
            this.tbSearchPath.Size = new System.Drawing.Size(677, 20);
            this.tbSearchPath.TabIndex = 1;
            this.tbSearchPath.Text = "c:\\";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(802, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(768, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(28, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(197, 557);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(680, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(197, 557);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(680, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Cleanup all duplicates";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FileForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 592);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearchPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.duplicatesPanel);
            this.Controls.Add(this.lbDuplicateSets);
            this.Name = "FileForm";
            this.Text = "File Duplicate Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbDuplicateSets;
        private System.Windows.Forms.Panel duplicatesPanel;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox tbSearchPath;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button btnDelete;
    }
}

