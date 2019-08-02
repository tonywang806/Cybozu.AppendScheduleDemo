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
    public partial class frmSentMessageByWebBrowser : Form
    {
        Base baseInfo;
        int sentcount = 0;

        bool isCreateMessage = false;
        bool isRedirected = false;
        string strCreateMessageFormUrl = "http://cybozu.chiyodagravure.local/scripts/cbag/ag.exe?page=MyFolderMessageSend&fid=&cp=ml";

        int QueueLength = 0;
        int QIndex = 0;

        public frmSentMessageByWebBrowser()
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
            emptyRow.Name = "(全員)";
            baseInfoDataSet.Organizations.Rows.Add(emptyRow);

            txtSubject.Text = string.Format("テストメッセージです。{0}", ++sentcount);
            txtContent.Text = txtSubject.Text;

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


        }

        private void SendMessageByWebView() {
            try
            {
                #region "メッセージを作成"

                MessageThread thread = new MessageThread();
                thread.subject = this.txtSubject.Text;


                HtmlElementCollection elementCollection = browser.Document.GetElementsByTagName("input");
                foreach (HtmlElement element in elementCollection)
                {
                    if (element.Name == "Subject")
                    {
                        element.InnerText = this.txtSubject.Text;
                        break;
                    }
                }

                Content c = new Content();
                c.Body = txtContent.Text;
                thread.content = c;

                HtmlElement txtElement = browser.Document.GetElementById("Data");

                if (txtElement is null) return;

                if (txtElement.Name == "Data")
                {
                    txtElement.InnerText = txtContent.Text;
                }

                elementCollection = browser.Document.GetElementsByTagName("select");
                StringBuilder sb = new StringBuilder();

                foreach (HtmlElement element in elementCollection)
                {
                    if (element.Name == "UID")
                    {

                        foreach (DataRow r in addressDataSet.Users.Rows)
                        {
                            Address addr = new Address();
                            addr.user_id = (string)r["UserId"];
                            addr.name = (string)r["UserName"];
                            addr.confirmed = false;
                            if (!thread.addresses.Contains(addr.user_id))
                            {
                                thread.addresses.Add(addr);

                                if (!element.InnerHtml.Contains(addr.name))
                                {
                                    element.InnerHtml = string.Format(@"<option value=""{0}"">{1}</option>", (string)r["UserId"], (string)r["UserName"]) + element.InnerHtml;
                                    sb.Append((string)r["UserName"] + ";");
                                }

                            }
                        }
                        break;
                    }
                }

                #endregion

                #region "メッセージ送信"
                ChangeLog create = new ChangeLog();
                thread.creator = create;

                elementCollection = browser.Document.GetElementsByTagName("input");
                foreach (HtmlElement element in elementCollection)
                {
                    if (element.Name == "Submit")
                    {
                        Object resp = element.InvokeMember("click");
                        thread.creator.date = DateTime.Now.ToString();
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("{0}回目送信完了{1} ", sentcount, DateTime.Now);

                        break;
                    }
                }
                #endregion

                #region "送信履歴更新"
                System.Threading.Thread.Sleep(1000);

                Model.BaseInfoDataSet.MessagesRow msg = addressDataSet.Messages.NewMessagesRow();
                MessageThread response = SearchMessage(thread);
                if (response == null)
                {
                    msg.SendDate = thread.creator.date;
                    msg.Addresses = thread.addresses.ToString();
                    msg.Content = thread.content.Body;
                    msg.MessageId = "99999";
                    msg.Title = thread.subject;
                    msg.Signature = thread.GetSignature();
                }
                else
                {
                    msg.SendDate = response.creator.date;
                    msg.Addresses = response.addresses.ToString();
                    msg.Content = response.content.Body;
                    msg.MessageId = response.id;
                    msg.Title = response.subject;
                    msg.Signature = response.GetSignature();
                }
                Console.WriteLine("Message ID:{0}  Signature:{1}", msg.MessageId, msg.Signature);
                addressDataSet.Messages.Rows.Add(msg);
                #endregion

                #region "後処理"
                txtSubject.Text = string.Format("テストメッセージです。{0}", ++sentcount); ;
                //txtContent.Text = txtSubject.Text;
                #endregion

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

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (isCreateMessage) return;

            //browser.AllowNavigation = false;
            btnSendMessage.Enabled = false;

            QueueLength = 5;
            QIndex = 0;
            SendMessageByWebView();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void listDept_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listDept.SelectedValue.ToString() == "search")
            {
                return;
            }

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

                Organization org = organizationsList.Single(value => value.ID == listDept.SelectedValue.ToString());

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

            txtSearchUserNM.Clear();
            if (baseInfoDataSet.Organizations.Rows[0]["Id"].ToString() == "search")
            {
                listDept.SelectedValueChanged -= new EventHandler(listDept_SelectedValueChanged);
                baseInfoDataSet.Organizations.Rows.RemoveAt(0);
                baseInfoDataSet.Organizations.AcceptChanges();
                listDept.SelectedValueChanged += new EventHandler(listDept_SelectedValueChanged);
            }
        }

        private void btnAddressAppend_Click(object sender, EventArgs e)
        {
            foreach (Object obj in listUsers.SelectedItems)
            {
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

        private bool IsUserSelected(string userId)
        {
            foreach (DataRow r in addressDataSet.Users.Rows)
            {
                if ((string)r["UserId"] == userId)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsFollowContains(string number)
        {
            bool contains = addressDataSet.Messages.AsEnumerable().Any(row => number == row.Field<String>("Number"));
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

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchUserNM.Text))
            {

                if (baseInfoDataSet.Organizations.Rows[0]["Id"].ToString() != "search")
                {
                    listDept.SelectedValueChanged -= new EventHandler(listDept_SelectedValueChanged);
                    Model.BaseInfoDataSet.OrganizationsRow searchRow = baseInfoDataSet.Organizations.NewOrganizationsRow();
                    searchRow.Id = "search";
                    searchRow.Name = "(検索結果)";
                    baseInfoDataSet.Organizations.Rows.InsertAt(searchRow, 0);
                    listDept.SelectedIndex = 0;

                    listDept.SelectedValueChanged += new EventHandler(listDept_SelectedValueChanged);
                }
                string searchNm = txtSearchUserNM.Text;
                baseInfoDataSet.Users.Clear();

                UserCollection usersList = baseInfo.Users;
                foreach (User usr in usersList)
                {
                    if (usr.Name.Contains(searchNm))
                    {
                        Model.BaseInfoDataSet.UsersRow r = baseInfoDataSet.Users.NewUsersRow();
                        r.UserId = usr.ID;
                        r.UserName = usr.Name;
                        baseInfoDataSet.Users.Rows.Add(r);
                    }
                }
                baseInfoDataSet.Users.AcceptChanges();
            }
        }

        private MessageThread SearchMessage(MessageThread request)
        {
            App app = ApplicationCache.CybozuApp;
            MessageClient msgClient = new MessageClient(app);
            SearchParameter sp = new SearchParameter();

            return SearchMessage(request.subject, request.GetSignature());
        }

        private MessageThread SearchMessage(string title,string messageSignature)
        {
            App app = ApplicationCache.CybozuApp;
            MessageClient msgClient = new MessageClient(app);
            SearchParameter sp = new SearchParameter();

            sp.Text = title;
            sp.Folder_id = "send";
            sp.Search_sub_folders = true;
            sp.Title_search = true;
            sp.Body_search = false;
            sp.From_search = false;
            sp.Addressee_search = false;
            sp.Follow_search = false;

            MessageThreadCollection threads = msgClient.MessageSearchThreads(sp);
            if (threads == null)
            {
                return null;
            }
            if (threads.Count == 1)
            {
                return threads[0];
            }
            foreach (MessageThread thread in threads)
            {
                if (thread.GetSignature() == messageSignature)
                {
                    return thread;
                }
            }
            return null;
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //Console.WriteLine("▽▽▽▽▽▽▽▽▽▽▽▽▽▽▽");
            //Console.WriteLine("browser_DocumentCompleted");
            //Console.WriteLine("browser.URL:{0}",browser.Url.ToString());
            //Console.WriteLine("e.URL:{0}",e.Url.ToString());
            //Console.WriteLine("△△△△△△△△△△△△△△△");
            if (isRedirected)
            {
                Console.WriteLine("Redirected");
                browser.Navigate(strCreateMessageFormUrl);

            }
            else {
                HtmlElementCollection elementCollection = browser.Document.GetElementsByTagName("input");
                foreach (HtmlElement element in elementCollection) {

                    if (element.Name== "_Account")
                    {
                        element.InnerText = "ict.system";
                        isCreateMessage = false;
                    }

                    if (element.Name == "Password")
                    {
                        element.InnerText = "ictsystem";
                    }

                }
                foreach (HtmlElement element in elementCollection)
                {
                    if (element.Name == "Submit")
                    {
                        if (element.OuterHtml.Contains("ログイン"))
                        {
                            Object response = element.InvokeMember("click");
                            Console.WriteLine("ログインしました");

                            return;
                        }
                    }
                }

                    //Console.WriteLine("自動応答処理追加");
                    //アラートが表示なら、自動的に閉じるように
                    HtmlElement head = browser.Document.GetElementsByTagName("head")[0];
                    HtmlElement script = browser.Document.CreateElement("script");
                    script.SetAttribute("type", "text/javascript");
                    String alertBlocker = "function confirm() {return true;} function alert() {}; ";
                    script.SetAttribute("text", alertBlocker);
                    head.AppendChild(script);

                //次回送信準備できるかどうかを判定
                if (browser.Url.ToString().Equals(strCreateMessageFormUrl) & e.Url.ToString().Equals("about:blank")) {

                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("{0}回目送信準備完了{1} ", sentcount, DateTime.Now);

                    QIndex++;

                    if (QIndex < QueueLength)
                    {
                        SendMessageByWebView();
                    }
                    else {
                        btnSendMessage.Enabled = true;
                    }
                }


            }
        }

        private void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (browser.Url.ToString() != strCreateMessageFormUrl)
            {
                isRedirected = true;
            }
            else {
                isRedirected = false;
            }
        }

        private void dgvMessage_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvMessage.Columns.Contains("messageIdDataGridViewTextBoxColumn")) return;
            string msgid_raw = dgvMessage.Rows[e.RowIndex].Cells["messageIdDataGridViewTextBoxColumn"].Value.ToString();
            string[] msgId = null;
            if (msgid_raw == "99999")
            {
                string title = dgvMessage.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                string signature = dgvMessage.Rows[e.RowIndex].Cells["Signature"].Value.ToString();
                MessageThread response = SearchMessage(title, signature);

                if (response == null)
                {
                    return;
                }
                else {
                    msgId = response.id.Split('-');
                }
            }
            else {
                msgId = dgvMessage.Rows[e.RowIndex].Cells["messageIdDataGridViewTextBoxColumn"].Value.ToString().Split('-');
            }

            System.Diagnostics.Process.Start(string.Format(@"http://cybozu.chiyodagravure.local/scripts/cbag/ag.exe?page=MyFolderMessageView&mDBID={0}&mDID={1}", msgId[0], msgId[1]));
        }
    }

}
