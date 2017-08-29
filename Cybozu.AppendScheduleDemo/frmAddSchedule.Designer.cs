namespace Cybozu.AppendScheduleDemo
{
    partial class frmAddSchedule
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSchedule));
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblMembers = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnAppend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtScheduleDate = new System.Windows.Forms.DateTimePicker();
            this.cbStartHour = new System.Windows.Forms.ComboBox();
            this.cbStartMin = new System.Windows.Forms.ComboBox();
            this.cbEndHour = new System.Windows.Forms.ComboBox();
            this.cbEndMin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPlan = new System.Windows.Forms.ComboBox();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lbMembers = new System.Windows.Forms.ListBox();
            this.lbConditionsMembers = new System.Windows.Forms.ListBox();
            this.btnDeleteMember = new System.Windows.Forms.Button();
            this.btnSelectMember = new System.Windows.Forms.Button();
            this.selectedMembersBS = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.selectedMembersBS)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(30, 74);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(29, 12);
            this.lblPlan.TabIndex = 0;
            this.lblPlan.Text = "予定";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(37, 100);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(22, 12);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "メモ";
            // 
            // lblMembers
            // 
            this.lblMembers.AutoSize = true;
            this.lblMembers.Location = new System.Drawing.Point(18, 188);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(41, 12);
            this.lblMembers.TabIndex = 0;
            this.lblMembers.Text = "参加者";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(30, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(29, 12);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "日付";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(30, 48);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(29, 12);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "時刻";
            // 
            // btnAppend
            // 
            this.btnAppend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAppend.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAppend.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAppend.ForeColor = System.Drawing.Color.White;
            this.btnAppend.Location = new System.Drawing.Point(237, 353);
            this.btnAppend.Name = "btnAppend";
            this.btnAppend.Size = new System.Drawing.Size(75, 32);
            this.btnAppend.TabIndex = 13;
            this.btnAppend.Text = "登録する";
            this.btnAppend.UseVisualStyleBackColor = false;
            this.btnAppend.Click += new System.EventHandler(this.btnAppend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(318, 353);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 32);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "キャンセルする";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtScheduleDate
            // 
            this.dtScheduleDate.Location = new System.Drawing.Point(74, 19);
            this.dtScheduleDate.Name = "dtScheduleDate";
            this.dtScheduleDate.Size = new System.Drawing.Size(126, 19);
            this.dtScheduleDate.TabIndex = 1;
            // 
            // cbStartHour
            // 
            this.cbStartHour.DisplayMember = "Display";
            this.cbStartHour.FormattingEnabled = true;
            this.cbStartHour.Location = new System.Drawing.Point(74, 44);
            this.cbStartHour.Name = "cbStartHour";
            this.cbStartHour.Size = new System.Drawing.Size(48, 20);
            this.cbStartHour.TabIndex = 2;
            this.cbStartHour.ValueMember = "Value";
            this.cbStartHour.SelectionChangeCommitted += new System.EventHandler(this.cbStartHour_SelectionChangeCommitted);
            // 
            // cbStartMin
            // 
            this.cbStartMin.DisplayMember = "Display";
            this.cbStartMin.FormattingEnabled = true;
            this.cbStartMin.Location = new System.Drawing.Point(128, 44);
            this.cbStartMin.Name = "cbStartMin";
            this.cbStartMin.Size = new System.Drawing.Size(48, 20);
            this.cbStartMin.TabIndex = 3;
            this.cbStartMin.ValueMember = "Value";
            // 
            // cbEndHour
            // 
            this.cbEndHour.DisplayMember = "Display";
            this.cbEndHour.FormattingEnabled = true;
            this.cbEndHour.Location = new System.Drawing.Point(206, 44);
            this.cbEndHour.Name = "cbEndHour";
            this.cbEndHour.Size = new System.Drawing.Size(48, 20);
            this.cbEndHour.TabIndex = 4;
            this.cbEndHour.ValueMember = "Value";
            this.cbEndHour.SelectionChangeCommitted += new System.EventHandler(this.cbEndHour_SelectionChangeCommitted);
            // 
            // cbEndMin
            // 
            this.cbEndMin.DisplayMember = "Display";
            this.cbEndMin.FormattingEnabled = true;
            this.cbEndMin.Location = new System.Drawing.Point(260, 44);
            this.cbEndMin.Name = "cbEndMin";
            this.cbEndMin.Size = new System.Drawing.Size(48, 20);
            this.cbEndMin.TabIndex = 5;
            this.cbEndMin.ValueMember = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "～";
            // 
            // cbPlan
            // 
            this.cbPlan.DisplayMember = "Display";
            this.cbPlan.FormattingEnabled = true;
            this.cbPlan.Location = new System.Drawing.Point(74, 70);
            this.cbPlan.Name = "cbPlan";
            this.cbPlan.Size = new System.Drawing.Size(71, 20);
            this.cbPlan.TabIndex = 6;
            this.cbPlan.ValueMember = "Value";
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(151, 70);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(262, 20);
            this.txtDetail.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(74, 96);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(339, 81);
            this.txtDescription.TabIndex = 8;
            // 
            // lbMembers
            // 
            this.lbMembers.DisplayMember = "Display";
            this.lbMembers.FormattingEnabled = true;
            this.lbMembers.ItemHeight = 12;
            this.lbMembers.Location = new System.Drawing.Point(74, 188);
            this.lbMembers.Name = "lbMembers";
            this.lbMembers.Size = new System.Drawing.Size(123, 148);
            this.lbMembers.TabIndex = 9;
            this.lbMembers.ValueMember = "Value";
            // 
            // lbConditionsMembers
            // 
            this.lbConditionsMembers.DisplayMember = "Display";
            this.lbConditionsMembers.FormattingEnabled = true;
            this.lbConditionsMembers.ItemHeight = 12;
            this.lbConditionsMembers.Location = new System.Drawing.Point(289, 188);
            this.lbConditionsMembers.Name = "lbConditionsMembers";
            this.lbConditionsMembers.Size = new System.Drawing.Size(123, 148);
            this.lbConditionsMembers.TabIndex = 11;
            this.lbConditionsMembers.ValueMember = "Value";
            // 
            // btnDeleteMember
            // 
            this.btnDeleteMember.Location = new System.Drawing.Point(216, 274);
            this.btnDeleteMember.Name = "btnDeleteMember";
            this.btnDeleteMember.Size = new System.Drawing.Size(54, 23);
            this.btnDeleteMember.TabIndex = 10;
            this.btnDeleteMember.Text = "→";
            this.btnDeleteMember.UseVisualStyleBackColor = true;
            this.btnDeleteMember.Click += new System.EventHandler(this.btnDeleteMember_Click);
            // 
            // btnSelectMember
            // 
            this.btnSelectMember.Location = new System.Drawing.Point(216, 232);
            this.btnSelectMember.Name = "btnSelectMember";
            this.btnSelectMember.Size = new System.Drawing.Size(54, 23);
            this.btnSelectMember.TabIndex = 12;
            this.btnSelectMember.Text = "←";
            this.btnSelectMember.UseVisualStyleBackColor = true;
            this.btnSelectMember.Click += new System.EventHandler(this.btnSelectMember_Click);
            // 
            // frmAddSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 397);
            this.Controls.Add(this.btnSelectMember);
            this.Controls.Add(this.btnDeleteMember);
            this.Controls.Add(this.lbConditionsMembers);
            this.Controls.Add(this.lbMembers);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEndMin);
            this.Controls.Add(this.cbStartMin);
            this.Controls.Add(this.cbEndHour);
            this.Controls.Add(this.cbPlan);
            this.Controls.Add(this.cbStartHour);
            this.Controls.Add(this.dtScheduleDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAppend);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblMembers);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPlan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAddSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "予定追加";
            this.Load += new System.EventHandler(this.frmAddSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selectedMembersBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblMembers;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnAppend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtScheduleDate;
        private System.Windows.Forms.ComboBox cbStartHour;
        private System.Windows.Forms.ComboBox cbStartMin;
        private System.Windows.Forms.ComboBox cbEndHour;
        private System.Windows.Forms.ComboBox cbEndMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPlan;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ListBox lbMembers;
        private System.Windows.Forms.ListBox lbConditionsMembers;
        private System.Windows.Forms.Button btnDeleteMember;
        private System.Windows.Forms.Button btnSelectMember;
        private System.Windows.Forms.BindingSource selectedMembersBS;
    }
}