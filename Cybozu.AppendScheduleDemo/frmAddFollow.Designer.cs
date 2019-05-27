namespace Cybozu.AppendScheduleDemo
{
    partial class frmAddFollow
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
            this.btnAddFollow = new System.Windows.Forms.Button();
            this.btnAttachFiles = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.lbMessage = new System.Windows.Forms.Label();
            this.txtContentText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAddFollow
            // 
            this.btnAddFollow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFollow.Location = new System.Drawing.Point(265, 110);
            this.btnAddFollow.Name = "btnAddFollow";
            this.btnAddFollow.Size = new System.Drawing.Size(75, 23);
            this.btnAddFollow.TabIndex = 1;
            this.btnAddFollow.Text = "送信";
            this.btnAddFollow.UseVisualStyleBackColor = true;
            this.btnAddFollow.Click += new System.EventHandler(this.btnAddFollow_Click);
            // 
            // btnAttachFiles
            // 
            this.btnAttachFiles.Location = new System.Drawing.Point(12, 111);
            this.btnAttachFiles.Name = "btnAttachFiles";
            this.btnAttachFiles.Size = new System.Drawing.Size(75, 23);
            this.btnAttachFiles.TabIndex = 3;
            this.btnAttachFiles.Text = "添付ファイル";
            this.btnAttachFiles.UseVisualStyleBackColor = true;
            this.btnAttachFiles.Click += new System.EventHandler(this.btnAttachFiles_Click);
            // 
            // ofd
            // 
            this.ofd.InitialDirectory = "C:\\";
            this.ofd.Multiselect = true;
            this.ofd.RestoreDirectory = true;
            this.ofd.Title = "開くファイルを選択してください";
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(12, 9);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(62, 12);
            this.lbMessage.TabIndex = 4;
            this.lbMessage.Text = "コメント内容";
            // 
            // txtContentText
            // 
            this.txtContentText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContentText.Location = new System.Drawing.Point(12, 24);
            this.txtContentText.Multiline = true;
            this.txtContentText.Name = "txtContentText";
            this.txtContentText.Size = new System.Drawing.Size(326, 81);
            this.txtContentText.TabIndex = 5;
            // 
            // frmAddFollow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 143);
            this.Controls.Add(this.txtContentText);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.btnAttachFiles);
            this.Controls.Add(this.btnAddFollow);
            this.Name = "frmAddFollow";
            this.Text = "frmAddFollow";
            this.Load += new System.EventHandler(this.frmAddFollow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddFollow;
        private System.Windows.Forms.Button btnAttachFiles;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.TextBox txtContentText;
    }
}