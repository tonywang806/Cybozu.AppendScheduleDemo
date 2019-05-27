using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using CBLabs.CybozuConnect;
using System.IO;


namespace Cybozu.AppendScheduleDemo
{
    public partial class frmAddFollow : Form
    {
        TextBox filesList = new TextBox();
        List<ContentFile> files = new List<ContentFile>();
        Base baseInfo;
        string ThreadId = "1-716673";

        public frmAddFollow()
        {
            InitializeComponent();
        }

        private void btnAttachFiles_Click(object sender, EventArgs e)
        {
            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileNames.Length == 0)
                {
                    return;
                }
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                StringBuilder sb = new StringBuilder();

                //▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
                for (int i=0;i<ofd.FileNames.Length;i++)
                {
                    string filepath = ofd.FileNames[i];

                    //todo : convert files to list
                    FileInfo fi = new FileInfo(filepath);
                    ContentFile attached = new ContentFile
                    {
                        id = i.ToString(),
                        name = fi.Name,
                        //mime_type = "application/octet-stream",
                        contentBase64 = Convert.ToBase64String(File.ReadAllBytes(filepath))
                    };
                    files.Add(attached);
                   
                    //画面表示用
                    sb.Append(filepath + "\r\n");
                }
                //▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲

                //画面表示用
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    string filepath = ofd.FileNames[i];
                    sb.Append(filepath + "\r\n");
                }
                filesList.Text = sb.ToString();
            }
            else {
                return;
            }

            if (! this.Controls.Contains(filesList)) {
                //show file name info display box
                filesList.Multiline = true;
                filesList.ReadOnly = true;
                filesList.ScrollBars = ScrollBars.Vertical;
                filesList.Location = new Point(12, 137);
                filesList.Name = "lbFilesList";
                filesList.Size = new Size(328, 52);
                filesList.TabIndex = 6;

                this.Controls.Add(filesList);
                this.Height += (filesList.Height + 30);

                filesList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            }
        }

        private void btnAddFollow_Click(object sender, EventArgs e)
        {
            //todo : input check
            if (txtContentText.Text.Trim() == string.Empty) {
                if (files.Count == 0) {
                        return;
                }
            }

            try
            {
                //▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
                //todo : create cybozu client
                App app = ApplicationCache.CybozuApp;
                MessageClient msgClient = new MessageClient(app);
                MessageThread response = null;

                //todo : sent message with attached files(include no attached files)
                response = msgClient.MessageAddFollowsWithFiles(ThreadId, txtContentText.Text, files);
                if (response != null) {
                    MessageBox.Show("サイボウズにコメントを追加しました！");
                }
                //▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲

                //initiallization
                txtContentText.Text = string.Empty;

                if (this.Controls.Contains(filesList))
                {
                    //Base64 encode file infos are cleared 
                    files.Clear();

                    //attached file names what are displayed in textbox are cleared
                    filesList.Text = string.Empty;
                    this.Controls.Remove(filesList);
                    this.Height -= (filesList.Height + 30);

                    filesList.Size = new Size(328, 52);
                    filesList.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                }

            }
            catch (CybozuException ex)
            {
                MessageBox.Show(string.Format("CybozuException:{0}", ex.Message));
            }
            catch (UriFormatException ex)
            {
                MessageBox.Show(string.Format("UriFormatException:{0}", ex.Message));
            }
            catch (WebException ex)
            {
                MessageBox.Show(string.Format("WebException:{0}", ex.Message));
            }

        }

        private void frmAddFollow_Load(object sender, EventArgs e)
        {
            App app = ApplicationCache.CybozuApp;
            baseInfo = new Base(app);
        }
    }
}
