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
            try
            {
                App app = ApplicationCache.CybozuApp;
                MessageClient msg = new MessageClient(app);

                MessageThread thread = new MessageThread();
                thread.subject = "SentMessageTest from C#";

                Address addr = new Address();
                addr.user_id = "10435";
                addr.name = "王　天義";
                thread.addresses.Add(addr);

                addr = new Address();
                addr.user_id = "5910";
                addr.name = "李　浩";
                thread.addresses.Add(addr);

                Content c = new Content();
                string html_content = @"<div><div style=""font-size: 15.04px; padding: 0.5em 0px;""><table style=""border-color: #2c2c2c; height: 503px;"" border=""1"" width=""1584""><tbody><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">機器名</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">IPアドレス</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">ドライブ</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">空き容量（GB）</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">&nbsp;前回容量</span><span style=""font-size: 18.6667px;"">（GB）</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">使用率</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">使用率推移</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">備考 or 増減のあるフォルダ</span></td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">Impostrip</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">192.168.1.33</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">276/299</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">276</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">7.7％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">E:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">1.50T/1.52T</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">1.50T</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">1.3％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">PC-OneFlow</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">10.20.2.69</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">74.5/99.6</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">74.4</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">25.2％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">↓</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;""><span style=""color: #000000;"">56.2/</span>99.9</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">56.5</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">43.7％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">↑</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">XMPie−Director</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">10.20.2.87</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">79.7/119</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">79.6</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">33.0％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">↓</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">397/399</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">397</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">0.5％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">Storage</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">10.20.2.195</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">77.7/99.6</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">77.7</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">21.9％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #0000ff;""><span style=""color: #000000;"">332/499</span></span></td><td style=""text-align: center;""><span style=""color: #000000;""><span style=""font-size: 18.6667px;"">313</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">33.4％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">↓</span></td><td>&nbsp;</td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">APL</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">10.20.2.56</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""color: #000000;""><span style=""font-size: 18.6667px;"">78.6/99.6</span></span></td><td style=""text-align: center;""><span style=""color: #000000;""><span style=""font-size: 18.6667px;"">78.6</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">21.0％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;<br></span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">99.8/99.9</span></td><td style=""text-align: center;""><span style=""color: #000000;""><span style=""font-size: 18.6667px;"">99.8</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">0.1%</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">Asura</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">10.20.2.154</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">172/199</span></td><td style=""text-align: center;""><span style=""color: #000000;""><span style=""font-size: 18.6667px;"">172</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">13.5％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #0000ff;""><span style=""color: #000000;"">74.3/99.9</span></span></td><td style=""text-align: center;""><span style=""color: #000000;""><span style=""font-size: 18.6667px;"">73.7</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">25.6％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">↓</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">WEB1</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">54.65.201.225</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;""><span style=""color: #000000;"">67.4/</span>99.6</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">67.4</span></td><td style=""text-align: center;""><span style=""color: #000000; font-size: 14pt;"">32.3％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #0000ff;""><span style=""color: #000000;"">121/199</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">123</span></td><td style=""text-align: center;""><span style=""color: #000000; font-size: 14pt;"">39.1％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">↑</span></td><td>&nbsp;</td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">CIERTO</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">52.198.155.141</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #0000ff;""><span style=""color: #000000;"">33.9/99.6</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">33.8</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">65.9％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">↓</span></td><td>&nbsp;</td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;""><span style=""color: #000000;"">1.48/3</span>.90T</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">0.73</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">62.0％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">↓</span></td><td><div>&nbsp;<span style=""font-size: 12pt;""><span style=""font-size: 14pt;"">9/8　ストレージ(D:)拡張　2.92T → 3.90T<br></span></span></div><div><span style=""font-size: 12pt;""><span style=""font-size: 14pt;"">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;社内データ一部（Printmedia内）削除</span></span></div></td></tr></tbody></table><div>&nbsp;</div><div>・<span style=""color: #008000;"">使用率75％超</span>&nbsp;：&nbsp;<span style=""font-size: 15.04px;"">対象なし</span><br>・<span style=""color: #ff0000;"">使用率80％超</span>&nbsp;：&nbsp;<span style=""font-size: 15.04px;"">対象なし</span></div></div></div>";
                //c.Body = "各位\r\n標題の件、回送します。\r\n追加要望はお早めに。\r\n王";
                c.Html_body = html_content;
                thread.content = c;


                MessageThread reponse = msg.MessageCreateThreads(thread);
                this.lblStatus.Text += reponse.id + "\r\n";
                if (reponse.content.Body != string.Empty)
                {
                    this.lblStatus.Text += reponse.content.Body + "\r\n";
                }

                if (reponse.content.Html_body != string.Empty)
                {
                    this.lblStatus.Text += reponse.content.Html_body + "\r\n";
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
    }
}
