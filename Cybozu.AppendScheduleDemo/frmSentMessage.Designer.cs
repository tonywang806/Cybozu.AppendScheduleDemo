namespace Cybozu.AppendScheduleDemo
{
    partial class frmSentMessage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.listAddresses = new System.Windows.Forms.ListBox();
            this.addressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addressDataSet = new Cybozu.AppendScheduleDemo.Model.BaseInfoDataSet();
            this.btnAddressAppend = new System.Windows.Forms.Button();
            this.btnAddressDelete = new System.Windows.Forms.Button();
            this.listUsers = new System.Windows.Forms.ListBox();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.baseInfoDataSet = new Cybozu.AppendScheduleDemo.Model.BaseInfoDataSet();
            this.listDept = new System.Windows.Forms.ComboBox();
            this.organizationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCreator = new System.Windows.Forms.Label();
            this.txtCreator = new System.Windows.Forms.Label();
            this.txtCreateDept = new System.Windows.Forms.Label();
            this.dgvMessage = new System.Windows.Forms.DataGridView();
            this.messagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SendDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Addresses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sendDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseInfoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.organizationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messagesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(82, 61);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(734, 23);
            this.txtSubject.TabIndex = 0;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSubject.Location = new System.Drawing.Point(30, 64);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(40, 16);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "標題";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblContent.Location = new System.Drawing.Point(28, 104);
            this.lblContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(40, 16);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = "本文";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(82, 104);
            this.txtContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(734, 262);
            this.txtContent.TabIndex = 2;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAddress.Location = new System.Drawing.Point(28, 391);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(40, 16);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "宛先";
            // 
            // listAddresses
            // 
            this.listAddresses.DataSource = this.addressBindingSource;
            this.listAddresses.DisplayMember = "UserName";
            this.listAddresses.FormattingEnabled = true;
            this.listAddresses.ItemHeight = 16;
            this.listAddresses.Location = new System.Drawing.Point(82, 391);
            this.listAddresses.Margin = new System.Windows.Forms.Padding(4);
            this.listAddresses.Name = "listAddresses";
            this.listAddresses.Size = new System.Drawing.Size(285, 196);
            this.listAddresses.TabIndex = 3;
            this.listAddresses.ValueMember = "UserId";
            // 
            // addressBindingSource
            // 
            this.addressBindingSource.DataMember = "Users";
            this.addressBindingSource.DataSource = this.addressDataSet;
            // 
            // addressDataSet
            // 
            this.addressDataSet.DataSetName = "BaseInfoDataSet";
            this.addressDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAddressAppend
            // 
            this.btnAddressAppend.Location = new System.Drawing.Point(396, 439);
            this.btnAddressAppend.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddressAppend.Name = "btnAddressAppend";
            this.btnAddressAppend.Size = new System.Drawing.Size(112, 31);
            this.btnAddressAppend.TabIndex = 4;
            this.btnAddressAppend.Text = "←追加";
            this.btnAddressAppend.UseVisualStyleBackColor = true;
            this.btnAddressAppend.Click += new System.EventHandler(this.btnAddressAppend_Click);
            // 
            // btnAddressDelete
            // 
            this.btnAddressDelete.Location = new System.Drawing.Point(396, 506);
            this.btnAddressDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddressDelete.Name = "btnAddressDelete";
            this.btnAddressDelete.Size = new System.Drawing.Size(112, 31);
            this.btnAddressDelete.TabIndex = 4;
            this.btnAddressDelete.Text = "削除→";
            this.btnAddressDelete.UseVisualStyleBackColor = true;
            this.btnAddressDelete.Click += new System.EventHandler(this.btnAddressDelete_Click);
            // 
            // listUsers
            // 
            this.listUsers.DataSource = this.usersBindingSource;
            this.listUsers.DisplayMember = "UserName";
            this.listUsers.FormattingEnabled = true;
            this.listUsers.ItemHeight = 16;
            this.listUsers.Location = new System.Drawing.Point(531, 439);
            this.listUsers.Margin = new System.Windows.Forms.Padding(4);
            this.listUsers.Name = "listUsers";
            this.listUsers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listUsers.Size = new System.Drawing.Size(285, 148);
            this.listUsers.TabIndex = 3;
            this.listUsers.ValueMember = "UserId";
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.baseInfoDataSet;
            // 
            // baseInfoDataSet
            // 
            this.baseInfoDataSet.DataSetName = "BaseInfoDataSet";
            this.baseInfoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listDept
            // 
            this.listDept.DataSource = this.organizationsBindingSource;
            this.listDept.DisplayMember = "Name";
            this.listDept.FormattingEnabled = true;
            this.listDept.Location = new System.Drawing.Point(531, 391);
            this.listDept.Margin = new System.Windows.Forms.Padding(4);
            this.listDept.Name = "listDept";
            this.listDept.Size = new System.Drawing.Size(285, 24);
            this.listDept.TabIndex = 5;
            this.listDept.ValueMember = "Id";
            // 
            // organizationsBindingSource
            // 
            this.organizationsBindingSource.DataMember = "Organizations";
            this.organizationsBindingSource.DataSource = this.baseInfoDataSet;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSendMessage.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSendMessage.Location = new System.Drawing.Point(314, 611);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(124, 44);
            this.btnSendMessage.TabIndex = 4;
            this.btnSendMessage.Text = "送信";
            this.btnSendMessage.UseVisualStyleBackColor = false;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(486, 611);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 44);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCreator.Location = new System.Drawing.Point(12, 24);
            this.lblCreator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(56, 16);
            this.lblCreator.TabIndex = 1;
            this.lblCreator.Text = "送信者";
            // 
            // txtCreator
            // 
            this.txtCreator.AutoSize = true;
            this.txtCreator.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtCreator.Location = new System.Drawing.Point(82, 24);
            this.txtCreator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtCreator.Name = "txtCreator";
            this.txtCreator.Size = new System.Drawing.Size(72, 16);
            this.txtCreator.TabIndex = 1;
            this.txtCreator.Text = "送信者名";
            // 
            // txtCreateDept
            // 
            this.txtCreateDept.AutoSize = true;
            this.txtCreateDept.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtCreateDept.Location = new System.Drawing.Point(267, 24);
            this.txtCreateDept.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtCreateDept.Name = "txtCreateDept";
            this.txtCreateDept.Size = new System.Drawing.Size(72, 16);
            this.txtCreateDept.TabIndex = 1;
            this.txtCreateDept.Text = "送信部署";
            // 
            // dgvMessage
            // 
            this.dgvMessage.AllowUserToAddRows = false;
            this.dgvMessage.AllowUserToDeleteRows = false;
            this.dgvMessage.AutoGenerateColumns = false;
            this.dgvMessage.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sendDateDataGridViewTextBoxColumn,
            this.addressesDataGridViewTextBoxColumn,
            this.contentDataGridViewTextBoxColumn,
            this.messageIdDataGridViewTextBoxColumn});
            this.dgvMessage.DataSource = this.messagesBindingSource;
            this.dgvMessage.Location = new System.Drawing.Point(825, 61);
            this.dgvMessage.Name = "dgvMessage";
            this.dgvMessage.RowTemplate.Height = 21;
            this.dgvMessage.Size = new System.Drawing.Size(667, 526);
            this.dgvMessage.TabIndex = 6;
            this.dgvMessage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMessage_CellContentClick);
            // 
            // messagesBindingSource
            // 
            this.messagesBindingSource.DataMember = "Messages";
            this.messagesBindingSource.DataSource = this.addressDataSet;
            // 
            // SendDate
            // 
            this.SendDate.DataPropertyName = "SendDate";
            this.SendDate.HeaderText = "送信日";
            this.SendDate.Name = "SendDate";
            // 
            // Addresses
            // 
            this.Addresses.DataPropertyName = "Addresses";
            this.Addresses.HeaderText = "宛先";
            this.Addresses.Name = "Addresses";
            this.Addresses.Width = 200;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SendDate";
            this.dataGridViewTextBoxColumn1.HeaderText = "送信日";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Addresses";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "宛先";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Content
            // 
            this.Content.DataPropertyName = "Content";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Content.DefaultCellStyle = dataGridViewCellStyle5;
            this.Content.HeaderText = "本文";
            this.Content.Name = "Content";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SendDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "SendDate";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Addresses";
            this.dataGridViewTextBoxColumn4.HeaderText = "Addresses";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Content";
            this.dataGridViewTextBoxColumn5.HeaderText = "Content";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // sendDateDataGridViewTextBoxColumn
            // 
            this.sendDateDataGridViewTextBoxColumn.DataPropertyName = "SendDate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.sendDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.sendDateDataGridViewTextBoxColumn.HeaderText = "送信日";
            this.sendDateDataGridViewTextBoxColumn.Name = "sendDateDataGridViewTextBoxColumn";
            this.sendDateDataGridViewTextBoxColumn.Width = 200;
            // 
            // addressesDataGridViewTextBoxColumn
            // 
            this.addressesDataGridViewTextBoxColumn.DataPropertyName = "Addresses";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.addressesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.addressesDataGridViewTextBoxColumn.HeaderText = "宛先";
            this.addressesDataGridViewTextBoxColumn.Name = "addressesDataGridViewTextBoxColumn";
            this.addressesDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.addressesDataGridViewTextBoxColumn.Width = 200;
            // 
            // contentDataGridViewTextBoxColumn
            // 
            this.contentDataGridViewTextBoxColumn.DataPropertyName = "Content";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.contentDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.contentDataGridViewTextBoxColumn.HeaderText = "本文";
            this.contentDataGridViewTextBoxColumn.Name = "contentDataGridViewTextBoxColumn";
            this.contentDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.contentDataGridViewTextBoxColumn.Width = 500;
            // 
            // messageIdDataGridViewTextBoxColumn
            // 
            this.messageIdDataGridViewTextBoxColumn.DataPropertyName = "MessageId";
            this.messageIdDataGridViewTextBoxColumn.HeaderText = "MessageId";
            this.messageIdDataGridViewTextBoxColumn.Name = "messageIdDataGridViewTextBoxColumn";
            this.messageIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmSentMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 677);
            this.Controls.Add(this.dgvMessage);
            this.Controls.Add(this.listDept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddressDelete);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnAddressAppend);
            this.Controls.Add(this.listUsers);
            this.Controls.Add(this.listAddresses);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.txtCreateDept);
            this.Controls.Add(this.txtCreator);
            this.Controls.Add(this.lblCreator);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.txtSubject);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSentMessage";
            this.Text = "frmSentMessage";
            this.Load += new System.EventHandler(this.frmSentMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseInfoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.organizationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messagesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ListBox listAddresses;
        private System.Windows.Forms.Button btnAddressAppend;
        private System.Windows.Forms.Button btnAddressDelete;
        private System.Windows.Forms.ListBox listUsers;
        private System.Windows.Forms.ComboBox listDept;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label txtCreator;
        private System.Windows.Forms.Label txtCreateDept;
        private Model.BaseInfoDataSet baseInfoDataSet;
        private System.Windows.Forms.BindingSource organizationsBindingSource;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private System.Windows.Forms.BindingSource addressBindingSource;
        private Model.BaseInfoDataSet addressDataSet;
        private System.Windows.Forms.DataGridView dgvMessage;
        private System.Windows.Forms.BindingSource messagesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SendDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Addresses;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn sendDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageIdDataGridViewTextBoxColumn;
    }
}