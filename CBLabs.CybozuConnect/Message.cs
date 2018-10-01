using System;
using System.Xml;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CBLabs.CybozuConnect
{

    public class MessageThread
    {
        private string idField;

        private string versionField;

        private string subjectField;

        private bool confirmField;

        private bool is_draftField;

        private AddresseeCollection addressesField=new AddresseeCollection();

        private Content contentField;

        private ThreadFollowCollection followField = new ThreadFollowCollection();

        private StringCollection folderField=new StringCollection();

        private ChangeLog creatorField;

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
                        id = Utility.SafeAttribute(childNode, "id"),
                        number = Utility.SafeAttribute(childNode, "number")
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

        public ThreadFollowCollection follow
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
    }

    public class AddresseeCollection : KeyedCollection<string, Address>
    {
        protected override string GetKeyForItem(Address item)
        {
            return item.user_id;
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

        private bool sizeFieldSpecified;

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

        public bool sizeSpecified
        {
            get
            {
                return this.sizeFieldSpecified;
            }
            set
            {
                this.sizeFieldSpecified = value;
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

        private string idField;

        private string numberField;

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

        public string number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

    }
    public class ThreadFollowCollection : KeyedCollection<string, ThreadFollow>
    {
        protected override string GetKeyForItem(ThreadFollow item)
        {
            return item.id;
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

                if (eventNode != null) {
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

        protected ListDictionary CreateMessageThreadParam(MessageThread message, bool modify)
        {
            if (message.addresses.Count == 0) return null;

            ListDictionary message_thread = new ListDictionary();
            message_thread["id"] = modify ? message.id : "dummy";
            message_thread["version"] = modify ? message.version : "999999";
            message_thread["subject"] = message.subject ;
            message_thread["confirm"] = modify ? message.confirm?"true":"false":"false";
            message_thread["is_draft"] = modify ? message.is_draft ? "true" : "false" : "false";
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

            if (message.content.Html_body != string.Empty)
            {
                content["body"] = "";
                content["html_body"] = message.content.Html_body;
            }

            return content;
        }
    }
}
