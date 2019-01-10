namespace Cybozu.AppendScheduleDemo
{
    partial class frmShowStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowStatus));
            this.lblStatus = new System.Windows.Forms.TextBox();
            this.btnGetStatus = new System.Windows.Forms.Button();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnGetMessage = new System.Windows.Forms.Button();
            this.btnSentMessage = new System.Windows.Forms.Button();
            this.btnSearchMessage = new System.Windows.Forms.Button();
            this.btnSendMessage2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(23, 35);
            this.lblStatus.Multiline = true;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblStatus.Size = new System.Drawing.Size(816, 279);
            this.lblStatus.TabIndex = 5;
            // 
            // btnGetStatus
            // 
            this.btnGetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetStatus.Location = new System.Drawing.Point(23, 327);
            this.btnGetStatus.Name = "btnGetStatus";
            this.btnGetStatus.Size = new System.Drawing.Size(92, 23);
            this.btnGetStatus.TabIndex = 6;
            this.btnGetStatus.Text = "Get Status";
            this.btnGetStatus.UseVisualStyleBackColor = true;
            this.btnGetStatus.Click += new System.EventHandler(this.btnGetStatus_Click);
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSchedule.Location = new System.Drawing.Point(744, 327);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(107, 23);
            this.btnAddSchedule.TabIndex = 7;
            this.btnAddSchedule.Text = "Add Schedule";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWelcome.Location = new System.Drawing.Point(21, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(818, 23);
            this.lblWelcome.TabIndex = 8;
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGetMessage
            // 
            this.btnGetMessage.Location = new System.Drawing.Point(121, 327);
            this.btnGetMessage.Name = "btnGetMessage";
            this.btnGetMessage.Size = new System.Drawing.Size(102, 23);
            this.btnGetMessage.TabIndex = 9;
            this.btnGetMessage.Text = "Get Message";
            this.btnGetMessage.UseVisualStyleBackColor = true;
            this.btnGetMessage.Click += new System.EventHandler(this.btnGetMessage_Click);
            // 
            // btnSentMessage
            // 
            this.btnSentMessage.Location = new System.Drawing.Point(229, 327);
            this.btnSentMessage.Name = "btnSentMessage";
            this.btnSentMessage.Size = new System.Drawing.Size(102, 23);
            this.btnSentMessage.TabIndex = 9;
            this.btnSentMessage.Text = "Sent Message";
            this.btnSentMessage.UseVisualStyleBackColor = true;
            this.btnSentMessage.Click += new System.EventHandler(this.btnSentMessage_Click);
            // 
            // btnSearchMessage
            // 
            this.btnSearchMessage.Location = new System.Drawing.Point(337, 327);
            this.btnSearchMessage.Name = "btnSearchMessage";
            this.btnSearchMessage.Size = new System.Drawing.Size(130, 23);
            this.btnSearchMessage.TabIndex = 10;
            this.btnSearchMessage.Text = "Search Meassage";
            this.btnSearchMessage.UseVisualStyleBackColor = true;
            this.btnSearchMessage.Click += new System.EventHandler(this.btnSearchMessage_Click);
            // 
            // btnSendMessage2
            // 
            this.btnSendMessage2.Location = new System.Drawing.Point(473, 327);
            this.btnSendMessage2.Name = "btnSendMessage2";
            this.btnSendMessage2.Size = new System.Drawing.Size(219, 23);
            this.btnSendMessage2.TabIndex = 9;
            this.btnSendMessage2.Text = "Sent Message by webbrower";
            this.btnSendMessage2.UseVisualStyleBackColor = true;
            this.btnSendMessage2.Click += new System.EventHandler(this.btnSendMessage2_Clicked);
            // 
            // frmShowStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 362);
            this.Controls.Add(this.btnSearchMessage);
            this.Controls.Add(this.btnSendMessage2);
            this.Controls.Add(this.btnSentMessage);
            this.Controls.Add(this.btnGetMessage);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnAddSchedule);
            this.Controls.Add(this.btnGetStatus);
            this.Controls.Add(this.lblStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShowStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cybozu情報表示";
            this.Load += new System.EventHandler(this.frmShowStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lblStatus;
        private System.Windows.Forms.Button btnGetStatus;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnGetMessage;
        private System.Windows.Forms.Button btnSentMessage;
        private System.Windows.Forms.Button btnSearchMessage;
        private System.Windows.Forms.Button btnSendMessage2;
    }
}