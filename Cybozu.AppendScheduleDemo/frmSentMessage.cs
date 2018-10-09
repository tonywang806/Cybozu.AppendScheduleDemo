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

namespace Cybozu.AppendScheduleDemo
{
    public partial class frmSentMessage : Form
    {
        Base baseInfo;
        string ThreadId = "1-662727";
        public frmSentMessage()
        {
            InitializeComponent();
        }

        private void frmSentMessage_Load(object sender, EventArgs e)
        {
            App app = ApplicationCache.CybozuApp;
            baseInfo = new Base(app);


            this.txtCreator.Text = ApplicationCache.CybozuApp.User.Name;
            this.txtCreateDept.Text = baseInfo.GetPrimaryOrganization(ApplicationCache.CybozuApp.User.ID, true).Name;

            #region "リスト初期化"
            //組織リスト初期化
            OrganizationCollection organizationsList = baseInfo.AllOrganizations;
            organizationsList.Sort("Name");
            Model.BaseInfoDataSet.OrganizationsRow emptyRow = baseInfoDataSet.Organizations.NewOrganizationsRow();
            emptyRow.Id = "empty";
            emptyRow.Name = "";
            baseInfoDataSet.Organizations.Rows.Add(emptyRow);

            foreach (Organization org in organizationsList)
            {
                //Console.WriteLine("Organization ID={0}  Name={1}  Order={2}", org.ID, org.Name, org.Order);
                Model.BaseInfoDataSet.OrganizationsRow r = baseInfoDataSet.Organizations.NewOrganizationsRow();
                r.Id = org.ID;
                r.Name = org.Name;

                baseInfoDataSet.Organizations.Rows.Add(r);
            }
            //社員リスト初期化
            UserCollection usersList = baseInfo.Users;
            foreach (User usr in usersList)
            {
                //Console.WriteLine("Organization ID={0}  Name={1}  Order={2}", org.ID, org.Name, org.Order);
                Model.BaseInfoDataSet.UsersRow r = baseInfoDataSet.Users.NewUsersRow();
                r.UserId = usr.ID;
                r.UserName = usr.Name;
                baseInfoDataSet.Users.Rows.Add(r);
            }

            listDept.SelectedValueChanged += new EventHandler(listDept_SelectedValueChanged);
            listUsers.ClearSelected();
            #endregion

            #region "ThreadInfo初期化"
            if (ThreadId != string.Empty)
            {
                MessageClient msgClient = new MessageClient(app);
                MessageThread response = msgClient.MessageGetThreadsById(ThreadId);

                Model.BaseInfoDataSet.MessagesRow msg = addressDataSet.Messages.NewMessagesRow();
                msg.SendDate = response.creator.date;
                msg.Addresses = response.addresses.ToString();
                msg.Content = response.content.Body;
                msg.MessageId = response.id;

                addressDataSet.Messages.Rows.Add(msg);

                //if (response.follows.Count > 0)
                //{
                //    ThreadFollowCollection tfcList = msgClient.MessageGetFollows(response.id);
                //    foreach (ThreadFollow fo in tfcList)
                //    {
                //        Model.BaseInfoDataSet.MessagesRow msgFollow = addressDataSet.Messages.NewMessagesRow();
                //        msgFollow.SendDate = fo.CreatorField.date;
                //        msgFollow.From = fo.CreatorField.name;
                //        msgFollow.Content =fo.Text;
                //        msgFollow.Number = fo.Number;

                //        addressDataSet.Messages.Rows.Add(msgFollow);

                //    }
                //}
            }

            #endregion
            
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                App app = ApplicationCache.CybozuApp;
                MessageClient msgClient = new MessageClient(app);
                MessageThread response = null;

                //if (this.ThreadId != string.Empty)
                //{
                //    //Threadが存在している場合（Followを追加）

                //    #region "メッセージ送信"
                //    response = msgClient.MessageAddFollows(this.ThreadId,txtContent.Text);
                //    #endregion

                //    #region "後処理"
                //    if (response != null)
                //    {
                //        MessageBox.Show(string.Format("メッセージID：{0}", response.id), "メッセージ送信しました。");

                //        #region "送信履歴更新"
                //        ThreadFollowCollection tfcList = msgClient.MessageGetFollows(response.id);

                //        foreach (ThreadFollow fo in tfcList)
                //        {
                //            if (!IsFollowContains(fo.Number)) {
                //                 Model.BaseInfoDataSet.MessagesRow msg = addressDataSet.Messages.NewMessagesRow();
                //                msg.SendDate = fo.CreatorField.date;
                //                msg.From = fo.CreatorField.name;
                //                msg.Content = fo.Text;
                //                msg.Number = fo.Number;

                //                addressDataSet.Messages.Rows.Add(msg);
                //            }

                //        }

                //        #endregion

                //    }
                //    #endregion
                //}
                //else
                //{
                    //Threadが存在ない場合（Threadを新規作成）

                    #region "メッセージを作成"
                    MessageThread thread = new MessageThread();
                    thread.subject = this.txtSubject.Text;

                    foreach (DataRow r in addressDataSet.Users.Rows)
                    {
                        Address addr = new Address();
                        addr.user_id = (string)r["UserId"];
                        addr.name = (string)r["UserName"];
                        thread.addresses.Add(addr);
                    }

                    Content c = new Content();
                    //string html_content = @"<div><div style=""font-size: 15.04px; padding: 0.5em 0px;""><table style=""border-color: #2c2c2c; height: 503px;"" border=""1"" width=""1584""><tbody><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">機器名</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">IPアドレス</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">ドライブ</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">空き容量（GB）</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">&nbsp;前回容量</span><span style=""font-size: 18.6667px;"">（GB）</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">使用率</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">使用率推移</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">備考 or 増減のあるフォルダ</span></td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">Impostrip</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">192.168.1.33</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">276/299</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">276</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">7.7％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">E:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">1.50T/1.52T</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">1.50T</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">1.3％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">PC-OneFlow</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">10.20.2.69</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">74.5/99.6</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">74.4</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">25.2％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">↓</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;""><span style=""color: #000000;"">56.2/</span>99.9</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">56.5</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">43.7％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">↑</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">XMPie−Director</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">10.20.2.87</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">79.7/119</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">79.6</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">33.0％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">↓</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">397/399</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">397</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">0.5％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">Storage</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">10.20.2.195</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">77.7/99.6</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">77.7</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">21.9％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #0000ff;""><span style=""color: #000000;"">332/499</span></span></td><td style=""text-align: center;""><span style=""color: #000000;""><span style=""font-size: 18.6667px;"">313</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">33.4％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">↓</span></td><td>&nbsp;</td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">APL</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">10.20.2.56</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""color: #000000;""><span style=""font-size: 18.6667px;"">78.6/99.6</span></span></td><td style=""text-align: center;""><span style=""color: #000000;""><span style=""font-size: 18.6667px;"">78.6</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">21.0％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;<br></span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">99.8/99.9</span></td><td style=""text-align: center;""><span style=""color: #000000;""><span style=""font-size: 18.6667px;"">99.8</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">0.1%</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">Asura</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">10.20.2.154</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">172/199</span></td><td style=""text-align: center;""><span style=""color: #000000;""><span style=""font-size: 18.6667px;"">172</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">13.5％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #0000ff;""><span style=""color: #000000;"">74.3/99.9</span></span></td><td style=""text-align: center;""><span style=""color: #000000;""><span style=""font-size: 18.6667px;"">73.7</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">25.6％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">↓</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">WEB1</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">54.65.201.225</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;""><span style=""color: #000000;"">67.4/</span>99.6</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">67.4</span></td><td style=""text-align: center;""><span style=""color: #000000; font-size: 14pt;"">32.3％</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">→</span></td><td><span style=""font-size: 14pt;"">&nbsp;</span></td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #0000ff;""><span style=""color: #000000;"">121/199</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">123</span></td><td style=""text-align: center;""><span style=""color: #000000; font-size: 14pt;"">39.1％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">↑</span></td><td>&nbsp;</td></tr><tr><td rowspan=""2""><span style=""font-size: 14pt;"">CIERTO</span></td><td rowspan=""2""><span style=""font-size: 14pt;"">52.198.155.141</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">C:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #0000ff;""><span style=""color: #000000;"">33.9/99.6</span></span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">33.8</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">65.9％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">↓</span></td><td>&nbsp;</td></tr><tr><td style=""text-align: center;""><span style=""font-size: 14pt;"">D:</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;""><span style=""color: #000000;"">1.48/3</span>.90T</span></td><td style=""text-align: center;""><span style=""font-size: 14pt;"">0.73</span></td><td style=""text-align: center;""><span style=""font-size: 14pt; color: #000000;"">62.0％</span></td><td style=""text-align: center;""><span style=""font-size: 18.6667px;"">↓</span></td><td><div>&nbsp;<span style=""font-size: 12pt;""><span style=""font-size: 14pt;"">9/8　ストレージ(D:)拡張　2.92T → 3.90T<br></span></span></div><div><span style=""font-size: 12pt;""><span style=""font-size: 14pt;"">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;社内データ一部（Printmedia内）削除</span></span></div></td></tr></tbody></table><div>&nbsp;</div><div>・<span style=""color: #008000;"">使用率75％超</span>&nbsp;：&nbsp;<span style=""font-size: 15.04px;"">対象なし</span><br>・<span style=""color: #ff0000;"">使用率80％超</span>&nbsp;：&nbsp;<span style=""font-size: 15.04px;"">対象なし</span></div></div></div>";
                    //c.Html_body = html_content;

                    c.Body = txtContent.Text;
                    thread.content = c;
                    #endregion

                    #region "メッセージ送信"
                    response = msgClient.MessageCreateThreads(thread);
                    #endregion

                    #region "後処理"
                    if (response != null)
                    {
                        MessageBox.Show(string.Format("メッセージID：{0}", response.id), "メッセージ送信しました。");

                        #region "送信履歴更新"
                        Model.BaseInfoDataSet.MessagesRow msg = addressDataSet.Messages.NewMessagesRow();
                        msg.SendDate = response.creator.date;
                        msg.Addresses = response.addresses.ToString();
                        msg.Content = response.content.Body;
                        msg.MessageId = response.id;

                        addressDataSet.Messages.Rows.Add(msg);
                        #endregion

                    }
                    #endregion

                //}



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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void listDept_SelectedValueChanged(object sender, EventArgs e)
        {

            if (listDept.SelectedValue.ToString() == "empty")
            {
                baseInfoDataSet.Users.Clear();

                UserCollection usersList = baseInfo.Users;
                foreach (User usr in usersList)
                {
                    //Console.WriteLine("Organization ID={0}  Name={1}  Order={2}", org.ID, org.Name, org.Order);
                    Model.BaseInfoDataSet.UsersRow r = baseInfoDataSet.Users.NewUsersRow();
                    r.UserId = usr.ID;
                    r.UserName = usr.Name;
                    baseInfoDataSet.Users.Rows.Add(r);
                }
                baseInfoDataSet.Users.AcceptChanges();
            }
            else
            {
                OrganizationCollection organizationsList = baseInfo.AllOrganizations;

                Organization org = organizationsList.Single(value =>value.ID==listDept.SelectedValue.ToString());

                baseInfoDataSet.Users.Clear();

                UserCollection usersList = baseInfo.Users;
                foreach (User usr in usersList)
                {
                    if (!org.UserIds.Contains(usr.ID)) continue;
                    //Console.WriteLine("Organization ID={0}  Name={1}  Order={2}", org.ID, org.Name, org.Order);
                    Model.BaseInfoDataSet.UsersRow r = baseInfoDataSet.Users.NewUsersRow();
                    r.UserId = usr.ID;
                    r.UserName = usr.Name;
                    baseInfoDataSet.Users.Rows.Add(r);
                }
                baseInfoDataSet.Users.AcceptChanges();

            }
            listUsers.ClearSelected();
        }

        private void btnAddressAppend_Click(object sender, EventArgs e)
        {
            //SelectionMode=One
            //string selectedUserID = (string)listUsers.SelectedValue;
            //string selectedUserName = listUsers.Text;

            //if (addressDataSet.Users.Select(String.Format("UserId={0}", selectedUserID)).Length>0) return;
            //DataRow newRow = addressDataSet.Users.NewRow();
            //newRow.ItemArray = new object[]{ selectedUserID, selectedUserName };
            //addressDataSet.Users.Rows.Add(newRow);
            //addressDataSet.Users.AcceptChanges();

            //SelectionMode=Multiple Simple
            foreach (Object obj in listUsers.SelectedItems) {
                DataRowView drv = (DataRowView)obj;
                string selectedUserID = (string)drv.Row["UserId"];
                string selectedUserName = (string)drv.Row["UserName"];

                if (IsUserSelected(selectedUserID)) continue;
                DataRow newRow = addressDataSet.Users.NewRow();
                newRow.ItemArray = new object[] { selectedUserID, selectedUserName };
                addressDataSet.Users.Rows.Add(newRow);
                addressDataSet.Users.AcceptChanges();
            }

            listUsers.ClearSelected();

        }

        private void btnAddressDelete_Click(object sender, EventArgs e)
        {
            if (listAddresses.SelectedIndex == -1) return;

            DataRowView selectedUser = (DataRowView)listAddresses.SelectedItem;
            addressDataSet.Users.Rows.Remove(selectedUser.Row);
            addressDataSet.Users.AcceptChanges();
        }

        private bool IsUserSelected(string userId) {
            foreach(DataRow r in addressDataSet.Users.Rows)
            {
                if ((string)r["UserId"] == userId) {
                    return true;
                }
            }
            return false;
        }

        private bool IsFollowContains(string number)
        {
            bool contains = addressDataSet.Messages.AsEnumerable().Any(row => number == row.Field<String>("Number"));

            //foreach (DataRow r in addressDataSet.Messages.Rows)
            //{
            //    if ((string)r["Number"] == number)
            //    {
            //        return true;
            //    }
            //}
            return contains;
        }

        private void btnUsersSelectedClear_Click(object sender, EventArgs e)
        {
            listUsers.ClearSelected();
        }

        private void btnAddressSelectedClear_Click(object sender, EventArgs e)
        {
            listAddresses.ClearSelected();
        }

        private void dgvMessage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvMessage.Columns.Contains("MessageId")) return;
            string[] msgId = dgvMessage.Rows[e.RowIndex].Cells["MessageId"].Value.ToString().Split('-');
            System.Diagnostics.Process.Start(string.Format(@"http://cybozu.chiyodagravure.local/scripts/cbag/ag.exe?page=MyFolderMessageView&mDBID={0}&mDID={1}", msgId[0], msgId[1]));
        }
    }
}
