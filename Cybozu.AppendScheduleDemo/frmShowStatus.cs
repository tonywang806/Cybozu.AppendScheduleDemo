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
using System.Xml;
using System.Collections.Specialized;
using System.Net;

namespace Cybozu.AppendScheduleDemo
{
    public partial class frmShowStatus : Form
    {


        public frmShowStatus()
        {
            InitializeComponent();
        }

        private void btnGetStatus_Click(object sender, EventArgs e)
        {
            try
            {
                App app = ApplicationCache.CybozuApp;

                lblStatus.Text = "【ユーザー情報】";
                lblStatus.Text += "\r\n----------------------------------------";
                lblStatus.Text += String.Format("{0}Status:{1}", "\r\n", app.User.Status);
                lblStatus.Text += String.Format("{0}ID    :{1}", "\r\n", app.User.ID);
                lblStatus.Text += String.Format("{0}Email :{1}", "\r\n", app.User.Email);

                lblStatus.Text += "\r\n";
                lblStatus.Text += "\r\n【Cybozuのステータス情報】";
                lblStatus.Text += "\r\n----------------------------------------";

                Base b = new Base(app);
                lblStatus.Text += "-------------組織図---------------------\r\n";
                foreach (var u in b.Users)
                {
                    lblStatus.Text += String.Format("ID:{0} Name :{1} Status:{2} Organization:{3}{4}", u.ID, u.Name, u.Status, u.PrimaryOrganizationId, "\r\n");

                }

                lblStatus.Text += "\r\n----------------------------------------";
                XmlElement resultNode = app.Query("Base", "BaseGetApplicationStatus", new ListDictionary());
                //XmlNode statusNode = resultNode.SelectSingleNode("//application[@code='schedule']");
                //if (statusNode == null)
                //{
                //    throw new CybozuException("Fail to auth.");
                //}
                //lblStatus.Text += String.Format("{0}Schdule Status :{1}", "\r\n", Utility.SafeAttribute(statusNode, "status")); 

                XmlNodeList statusNodeList = resultNode.SelectNodes("//application");
                foreach (XmlNode statusNode in statusNodeList)
                {
                    lblStatus.Text += String.Format("{0}{1} Status :{2}", "\r\n", Utility.SafeAttribute(statusNode, "code"), Utility.SafeAttribute(statusNode, "status"));
                }

                lblStatus.Text += "\r\n";
                lblStatus.Text += "\r\n【Cybozuのスケジュール情報】";
                lblStatus.Text += "\r\n----------------------------------------";

                Schedule s = new Schedule(app);
                DateTime current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                ScheduleEventCollection sc = s.GetEventsByTarget(current, current.AddDays(1), Schedule.TargetType.User, app.User.ID);

                foreach (ScheduleEvent se in sc)
                {
                    lblStatus.Text += String.Format("{0}Schedule :{1}", "\r\n", se.Start);
                    lblStatus.Text += String.Format("{0}  EventType:{1}", "\r\n", se.EventType);
                    lblStatus.Text += String.Format("{0}  PublicType:{1}", "\r\n", se.PublicType);
                    lblStatus.Text += String.Format("{0}  Plan:{1}", "\r\n", se.Plan);
                    lblStatus.Text += String.Format("{0}  Detail:{1}", "\r\n", se.Detail);
                    lblStatus.Text += String.Format("{0}  Description:{1}", "\r\n", se.Description);
                    //lblStatus.Text += String.Format("{0}  AllDay:{1}", "\r\n", se.AllDay);
                    //lblStatus.Text += String.Format("{0}  StartOnly:{1}", "\r\n", se.StartOnly);
                    //lblStatus.Text += String.Format("{0}  UserIds:{1}", "\r\n", se.UserIds);
                    //lblStatus.Text += String.Format("{0}  OrganizaitonIds:{1}", "\r\n", se.OrganizaitonIds);
                    //lblStatus.Text += String.Format("{0}  Start:{1}", "\r\n", se.Start);
                    //lblStatus.Text += String.Format("{0}  End:{1}", "\r\n", se.End);
                    //lblStatus.Text += String.Format("{0}  ID:{1}", "\r\n", se.ID);
                    //lblStatus.Text += String.Format("{0}  Version:{1}", "\r\n", se.Version);
                    //Console.WriteLine(se.Detail);
                }


                Properties.Settings.Default.Save();
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

        private void frmShowStatus_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = String.Format("よこそう！{0}さん", ApplicationCache.CybozuApp.User.Name);
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            frmAddSchedule frm = new frmAddSchedule();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ApplicationCache.CybozuApp.Refresh();
                btnGetStatus.PerformClick();
            }
        }

        private void btnGetMessage_Click(object sender, EventArgs e)
        {
            try
            {
                App app = ApplicationCache.CybozuApp;
                MessageClient msg = new MessageClient(app);
                MessageThread reponse = msg.MessageGetThreadsById("6-500269");
                this.lblStatus.Text += reponse.id + "\r\n";
                this.lblStatus.Text += reponse.content.Body + "\r\n";

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

        private void btnSentMessage_Click(object sender, EventArgs e)
        {
            frmSentMessage m = new frmSentMessage();
            DialogResult r = m.ShowDialog();

        }
    }
}
