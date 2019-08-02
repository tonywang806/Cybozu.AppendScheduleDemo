using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBLabs.CybozuConnect;

namespace Cybozu.AppendScheduleDemo
{
    public partial class frmSearchMessage : Form
    {
        public frmSearchMessage()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            App app = ApplicationCache.CybozuApp;
            MessageClient msgClient = new MessageClient(app);
            SearchParameter sp = new SearchParameter();

            sp.Text = txtSearchString.Text;
            sp.Folder_id = cmbFolders.SelectedText;
            sp.Search_sub_folders = true;
            sp.Title_search = chkTitle.Checked;
            sp.Body_search = chkBody.Checked;
            sp.From_search = chkFrom.Checked;
            sp.Addressee_search = chkAddress.Checked;
            sp.Follow_search = chkFollow.Checked;
            //sp.Start = DateTime.Now.AddMinutes(-5);

            MessageThreadCollection threads =msgClient.MessageSearchThreads(sp);

            StringBuilder sb = new StringBuilder();

            foreach (MessageThread thread in threads) {
                sb.Clear();

                foreach (Address adds in thread.addresses)
                {
                    sb.Append(adds.name + ";");
                }
                string result = string.Format("Address：{0}\r\nBody:\r\n{1}", sb.ToString(),thread.content.Body);
                MessageBox.Show(string.Format("Signature:{0}\r\nMessage:\r\n{1}", thread.GetSignature(), result));           
            }

        }
    }
}
