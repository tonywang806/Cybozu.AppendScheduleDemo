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
using System.Net;
using System.Collections.Specialized;
using System.Xml;

namespace Cybozu.AppendScheduleDemo
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            App app;
            string url = "http://cybozu.chiyodagravure.local/scripts/cbag/ag.exe";

            try
            {
                app = new App(url);
                app.Auth(this.txtUser.Text, this.txtPassword.Text);

                ApplicationCache.CybozuApp = app;

                frmShowStatus frm = new frmShowStatus();
                this.Hide();
                frm.Show();
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
    }
}
