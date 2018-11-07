using System;
using System.Xml;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace CBLabs.CybozuConnect
{
    public class MessageThread
    {
        //thread @Id
        private string idField;
        //thread @Version
        private string versionField;
        //thread @Subject ⇒ 題名
        private string subjectField;
        //thread @confirm ⇒ 閲覧状況を確認するかどうか
        private bool confirmField;
        //thread @is_draft ⇒ 下書きかどうか
        private bool is_draftField;
        //thread/addressee/ ⇒ 宛先の情報
        private AddresseeCollection addressesField=new AddresseeCollection();
        //thread/content/ ⇒ メッセージの本文
        private Content contentField;
        //thread/content/ ⇒ メッセージのフォローの情報
        private ThreadFollowCollection followField = new ThreadFollowCollection();
        //thread/folder/⇒ メッセージが存在するフォルダの情報
        private StringCollection folderField=new StringCollection();
        //thread/folder/⇒ メッセージの作成者
        private ChangeLog creatorField;
        //thread/folder/⇒ メッセージの更新者
        private ChangeLog modifierField;

        public MessageThread()
        {
        }
        public MessageThread(XmlNode eventNode)
        {
            this.id = Utility.SafeAttribute(eventNode, "id");
            this.version = Utility.SafeAttribute(eventNode, "version");
            this.confirm = (Utility.SafeAttribute(eventNode, "confirm").ToLowerInvariant() == bool.TrueString.ToLowerInvariant());
            this.subject = Utility.SafeAttribute(eventNode, "subject");
            this.is_draft =  (Utility.SafeAttribute(eventNode, "is_draft").ToLowerInvariant() == bool.TrueString.ToLowerInvariant());

            foreach (XmlNode childNode in eventNode.ChildNodes)
            {   
                // address
                if (childNode.Name == "addressee")
                {

                    Address addressee = new Address
                    {
                        user_id = Utility.SafeAttribute(childNode, "user_id"),
                        name = Utility.SafeAttribute(childNode, "name")
                    };

                    this.addressesField.Add(addressee);
                }

                // content
                if (childNode.Name== "content") {
                    this.contentField = new Content()
                    {
                        Body= Utility.SafeAttribute(childNode, "body"),
                        Html_body = Utility.SafeAttribute(childNode, "html_body")
                    };

                    foreach (XmlNode fileNode in childNode.ChildNodes)
                    {
                        if (fileNode.Name == "file") {
                            ContentFile file = new ContentFile();
                            file.id = Utility.SafeAttribute(fileNode, "id");
                            file.name = Utility.SafeAttribute(fileNode, "name");
                            file.mime_type = Utility.SafeAttribute(fileNode, "mime_type");
                            this.contentField.file.Add(file);
                        }
                    }
                }

                //  follows
                if (childNode.Name == "follow")
                {
                    ThreadFollow follow = new ThreadFollow()
                    {
                        Id = Utility.SafeAttribute(childNode, "id"),
                        Number = Utility.SafeAttribute(childNode, "number")
                    };

                    this.followField.Add(follow);
                }

                //  folder
                if (childNode.Name == "folder")
                {
                    this.folderField.Add(Utility.SafeAttribute(childNode, "id"));                   
                }
                //  creator
                
                if (childNode.Name == "creator")
                {
                    ChangeLog creator = new ChangeLog()
                    {
                        user_id = Utility.SafeAttribute(childNode, "user_id"),
                        name = Utility.SafeAttribute(childNode, "name"),
                        date= Utility.SafeAttribute(childNode, "date")

                    };

                    this.creator = creator;
                }
                //  modifier
                if (childNode.Name == "follow")
                {
                    ChangeLog modifier = new ChangeLog()
                    {
                        user_id = Utility.SafeAttribute(childNode, "user_id"),
                        name = Utility.SafeAttribute(childNode, "name"),
                        date = Utility.SafeAttribute(childNode, "date")

                    };

                    this.modifier = modifier;
                }
            }
        }

        public AddresseeCollection addresses
        {
            get
            {
                return this.addressesField;
            }
            set
            {
                this.addressesField = value;
            }
        }

        public Content content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }

        public ThreadFollowCollection follows
        {
            get
            {
                return this.followField;
            }
            set
            {
                this.followField = value;
            }
        }

        public StringCollection folder
        {
            get
            {
                return this.folderField;
            }
            set
            {
                this.folderField = value;
            }
        }

        public ChangeLog creator
        {
            get
            {
                return this.creatorField;
            }
            set
            {
                this.creatorField = value;
            }
        }

        public ChangeLog modifier
        {
            get
            {
                return this.modifierField;
            }
            set
            {
                this.modifierField = value;
            }
        }

        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        public string subject
        {
            get
            {
                return this.subjectField;
            }
            set
            {
                this.subjectField = value;
            }
        }

        public bool confirm
        {
            get
            {
                return this.confirmField;
            }
            set
            {
                this.confirmField = value;
            }
        }


        public bool is_draft
        {
            get
            {
                return this.is_draftField;
            }
            set
            {
                this.is_draftField = value;
            }
        }

    }
    public class Address
    {

        private string user_idField;

        private string nameField;

        private bool confirmedField;


        public string user_id
        {
            get
            {
                return this.user_idField;
            }
            set
            {
                this.user_idField = value;
            }
        }

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        public bool confirmed { get => confirmedField; set => confirmedField = value; }
    }
    public class AddresseeCollection : KeyedCollection<string, Address>
    {
        protected override string GetKeyForItem(Address item)
        {
            return item.user_id;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Address item in this) {
                sb.Append(item.name);
                sb.Append(";");
            }
            return sb.ToString();
        }

    }
    public class Content
    {
        private ContentFilesCollection fileField = new ContentFilesCollection();

        private string bodyField;

        private string html_bodyField;

        /// <remarks/>
        public ContentFilesCollection file{ get =>fileField;set =>fileField = value;}
        /// <remarks/>
        public string Body { get => bodyField; set => bodyField = value; }

        public string Html_body { get => html_bodyField; set => html_bodyField = value; }
    }
    public class ContentFile
    {

        private string idField;

        private string nameField;

        private ulong sizeField;

        private string mime_typeField;

        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        public ulong size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        public string mime_type
        {
            get
            {
                return this.mime_typeField;
            }
            set
            {
                this.mime_typeField = value;
            }
        }

    }
    public class ContentFilesCollection : KeyedCollection<string, ContentFile>
    {
        protected override string GetKeyForItem(ContentFile item)
        {
            return item.id;
        }
    }
    public class ThreadFollow
    {
        //follow @id ⇒ メッセージを識別するID
        private string id;
        //follow @number ⇒ フォロー番号
        private string number;
        //follow @text ⇒ フォローの内容
        private string text;
        //follow @html_text ⇒ フォローの内容(書式編集)
        private string html_text;
        //follow/creator ⇒ フォローの作成者情報を格納する要素
        private ChangeLog creatorField;
        //follow/file ⇒ 添付ファイルの情報を格納する要素
        private ContentFilesCollection fileField = new ContentFilesCollection();

        public string Id { get => id; set => id = value; }
        public string Number { get => number; set => number = value; }
        public string Text { get => text; set => text = value; }
        public string Html_text { get => html_text; set => html_text = value; }
        public ChangeLog CreatorField { get => creatorField; set => creatorField = value; }
        public ContentFilesCollection FileField { get => fileField; set => fileField = value; }

        public ThreadFollow() {
        }

        public ThreadFollow(XmlNode eventNode)
        {
            this.id = Utility.SafeAttribute(eventNode, "id");
            this.number = Utility.SafeAttribute(eventNode, "number");
            this.text = Utility.SafeAttribute(eventNode, "text");

            foreach (XmlNode childNode in eventNode.ChildNodes)
            {
                //  creator
                if (childNode.Name == "creator")
                {
                    ChangeLog creator = new ChangeLog()
                    {
                        user_id = Utility.SafeAttribute(childNode, "user_id"),
                        name = Utility.SafeAttribute(childNode, "name"),
                        date = Utility.SafeAttribute(childNode, "date")

                    };

                    this.CreatorField = creator;
                }
            }
        }

     }
    public class ThreadFollowCollection : KeyedCollection<string, ThreadFollow>
    {
        protected override string GetKeyForItem(ThreadFollow item)
        {
            return item.Id;
        }
    }
    public class ChangeLog
    {

        private string user_idField;

        private string nameField;

        private string dateField;

        public string user_id
        {
            get
            {
                return this.user_idField;
            }
            set
            {
                this.user_idField = value;
            }
        }

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        public string date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

    }

    public class MessageClient
    {
        public readonly App App;
        public readonly Base Base;


        public MessageClient(App app)
        {
            this.App = app;
            this.Base = this.App.Base;

            if (this.Base == null)
            {
                this.Base = new Base(app);
            }
        }
        public MessageThread MessageCreateThreads(MessageThread message)
        {
            ListDictionary parameters = new ListDictionary();
            ListDictionary idParam = new ListDictionary();
            idParam["thread"] = CreateMessageThreadParam(message, false);
            parameters["create_thread"] = idParam;
            XmlElement result = this.App.Exec("Message", "MessageCreateThreads", parameters);
            return new MessageThread(result.FirstChild);
        }


        public MessageThread MessageGetThreadsById(string messageId)
        {
            if (string.IsNullOrEmpty(messageId))
            {
                throw new CybozuException("Message ID is not specified.");
            }

            ListDictionary parameters = new ListDictionary();
            ListDictionary idParam = new ListDictionary();
            idParam["innerValue"] = messageId;
            parameters["thread_id"] = idParam;

            XmlElement resultNode = this.App.Query("Message", "MessageGetThreadsById", parameters);
            try
            {
                //XmlNamespaceManager xmlNsManager = new XmlNamespaceManager(resultNode.OwnerDocument.NameTable);
                //xmlNsManager.AddNamespace("ns", "http://schemas.cybozu.co.jp/message/2008");

                //XmlNodeList eventNodeList = resultNode.SelectNodes("//ns:thread", xmlNsManager);
                XmlNode eventNode = resultNode.FirstChild;

                if (eventNode != null)
                {
                    MessageThread thread;
                    thread = new MessageThread(eventNode);
                    return thread;
                }

            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
            return null;

        }

        public MessageThread MessageAddFollows(string messageId,string content)
        {
            ListDictionary parameters = new ListDictionary();
            ListDictionary idParam = new ListDictionary();
            ListDictionary followParam = new ListDictionary();
            followParam["text"] = content;
            idParam["thread_id"] = messageId;
            idParam["follow"] = followParam;
            parameters["add_follows"] = idParam;
            XmlElement result = this.App.Exec("Message", "MessageAddFollows", parameters);
            return new MessageThread(result.FirstChild);
        }


            public ThreadFollowCollection MessageGetFollows(string messageId, string offset = "0" ,string limit="10")
        {
            if (string.IsNullOrEmpty(messageId))
            {
                throw new CybozuException("Message ID is not specified.");
            }

            ListDictionary parameters = new ListDictionary();
            parameters["thread_id"] = messageId;
            parameters["offset"] = "0";
            parameters["limit"] = "10";

            XmlElement resultNode = this.App.Query("Message", "MessageGetFollows", parameters);
            try
            {
                XmlNamespaceManager xmlNsManager = new XmlNamespaceManager(resultNode.OwnerDocument.NameTable);
                xmlNsManager.AddNamespace("ns", "http://schemas.cybozu.co.jp/message/2008");

                //XmlNodeList eventNodeList = resultNode.SelectNodes("//ns:thread", xmlNsManager);
                XmlNodeList eventNodeList = resultNode.SelectNodes("//ns:follow",xmlNsManager);
                ThreadFollowCollection tfcList = new ThreadFollowCollection();
                foreach (XmlNode eventNode in eventNodeList)
                {
                    if (eventNode != null)
                    {
                        ThreadFollow follow;
                        follow = new ThreadFollow(eventNode);
                        tfcList.Add(follow);
                    }
                }

                return tfcList;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return null;

        }

        protected ListDictionary CreateMessageThreadParam(MessageThread message, bool modify)
        {
            if (message.addresses.Count == 0) return null;

            ListDictionary message_thread = new ListDictionary();
            message_thread["id"] = modify ? message.id : "dummy";
            message_thread["version"] = modify ? message.version : "999999";
            message_thread["subject"] = message.subject ;
            message_thread["confirm"] = message.confirm?"true":"false";
            message_thread["is_draft"] = message.is_draft ? "true" : "false";
            message_thread["addressee"] = PrepareAddresses(message);
            message_thread["content"] = PrepareContent(message);


            return message_thread;
        }


        protected ArrayList PrepareAddresses(MessageThread message)
        {
            ArrayList memberList = new ArrayList();

            foreach (Address addr in message.addresses)
            {
                ListDictionary address = new ListDictionary();
                address["xmlns"] = "http://schemas.cybozu.co.jp/message/2008";
                address["user_id"] = addr.user_id;
                address["name"] = addr.name;
                address["confirmed"] = addr.confirmed;
                address["delete"] = "false";
                memberList.Add(address);
            }

           return memberList;
        }

        protected ListDictionary PrepareContent(MessageThread message)
        {
            ListDictionary content = new ListDictionary();
            content["xmlns"] = "http://schemas.cybozu.co.jp/message/2008";
            if (message.content.Body != string.Empty)
            {
                content["body"] = message.content.Body;
            }
            else
            {
                content["body"] = "";
                content["html_body"] = message.content.Html_body;
            }

            return content;
        }
    }
}
