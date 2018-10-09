using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Xml;

namespace CBLabs.CybozuConnect
{
    public class User
    {
        public string ID;
        public string Version;
        public string Name;
        public string LoginName;
        public string Email;
        public string Status;
        public string PrimaryOrganizationId;
        public StringCollection OrganizationIds;

        public User(XmlNode userNode)
        {
            this.ID = Utility.SafeAttribute(userNode, "key");
            this.Version = Utility.SafeAttribute(userNode, "version");
            this.Name = Utility.SafeAttribute(userNode, "name");
            this.Email = Utility.SafeAttribute(userNode, "email");
            this.Status = Utility.SafeAttribute(userNode, "status");
            this.PrimaryOrganizationId = Utility.SafeAttribute(userNode, "primary_organization");
            this.OrganizationIds = new StringCollection();
            foreach (XmlNode node in userNode.ChildNodes)
            {
                if (node.Name != "organizaiton") continue;
                string orgId = Utility.SafeAttribute(node, "id");
                if (string.IsNullOrEmpty(orgId)) continue;
                this.OrganizationIds.Add(orgId);
            }
        }
    }

    public class UserCollection : KeyedCollection<string, User>
    {
        protected override string GetKeyForItem(User item)
        {
            return item.ID;
        }
    }

    public class Organization
    {
        public string ID;
        public string Version;
        private string nameField;
        public string ParentOrganizationId;
        public string Order;
        public StringCollection UserIds;
        public StringCollection OrganizationIds;

        public Organization(XmlNode orgNode)
        {
            this.ID = Utility.SafeAttribute(orgNode, "key");
            this.Version = Utility.SafeAttribute(orgNode, "version");
            this.nameField = Utility.SafeAttribute(orgNode, "name");
            this.ParentOrganizationId = Utility.SafeAttribute(orgNode, "parent_organization");
            this.Order = Utility.SafeAttribute(orgNode, "order");
            this.UserIds = new StringCollection();
            this.OrganizationIds = new StringCollection();
            foreach (XmlNode node in orgNode.ChildNodes)
            {
                if (node.Name == "members")
                {
                    foreach (XmlNode userNode in node.ChildNodes)
                    {
                        string userId = Utility.SafeAttribute(userNode, "id");
                        if (string.IsNullOrEmpty(userId)) continue;
                        this.UserIds.Add(userId);
                    }
                }
                else if (node.Name == "organization")
                {
                    string orgId = Utility.SafeAttribute(node, "key");
                    if (string.IsNullOrEmpty(orgId)) continue;
                    this.OrganizationIds.Add(orgId);
                }
            }
        }
        public string Name { set => this.nameField = value; get => this.nameField; }
    }

    public class OrganizationCollection : KeyedCollection<string, Organization>
    {
        
        protected override string GetKeyForItem(Organization item)
        {
            return item.ID;
        }
        public void Sort(string property)
        {
            List<Organization> list = base.Items as List<Organization>;
            if (list != null)
            {
                if (String.IsNullOrEmpty(property))
                {
                    property = "Key";
                }
                ObjectComparer<Organization> comparer = new ObjectComparer<Organization>(property);
                list.Sort(comparer);
            }
        }


    }
    class ObjectComparer<T> : Comparer<T>
    {
        PropertyInfo m_propertyInfo;

        public ObjectComparer(PropertyInfo pi)
        {
            m_propertyInfo = pi;
        }

        public ObjectComparer(string property)
        {
            m_propertyInfo = typeof(T).GetProperty(property);
        }

        public override int Compare(T x, T y)
        {
            Debug.Assert(m_propertyInfo != null);

            if (x == null && y == null)
            {
                return 0;
            }
            else if (x == null)
            {
                return -1;
            }

            IComparable xComparer = m_propertyInfo.GetValue(x, null) as IComparable;
            object yValue = m_propertyInfo.GetValue(y, null);

            if (xComparer == null)
            {
                throw new ArgumentOutOfRangeException("Object does not support IComparable interface");
            }

            return xComparer.CompareTo(yValue);

        }
    }

    public class Base
    {
        public readonly App App;

        protected bool hierarchical = false;
        protected UserCollection users;
        protected OrganizationCollection organizations;
        protected OrganizationCollection rootOrganizations;

        public Base(App app)
        {
            this.App = app;
            this.App.Base = this;
        }

        public UserCollection Users
        {
            get
            {
                InitUsers(false);
                return this.users;
            }
        }

        public UserCollection SearchUser(string text)
        {
            InitUsers(false);

            UserCollection result = new UserCollection();
            foreach (User user in this.users)
            {
                if (user.Name.IndexOf(text) >= 0 || user.Email.IndexOf(text) >= 0)
                {
                    result.Add(user);
                }
            }

            return result;
        }

        public void ReloadUsers()
        {
            InitUsers(true);
        }

        protected void InitUsers(bool force)
        {
            if (!force && this.users != null) return;

            XmlElement resultNode = this.App.QueryItems("Base", "BaseGetUserVersions", "BaseGetUsersById", "user_id", "user_item");
            XmlNodeList userList = resultNode.SelectNodes("//user");

            this.users = new UserCollection();
            foreach (XmlNode userNode in userList)
            {
                this.users.Add(new User(userNode));
            }
        }

        public OrganizationCollection RootOrganizations
        {
            get
            {
                InitOrganizations(false);
                return this.rootOrganizations;
            }
        }

        public OrganizationCollection AllOrganizations
        {
            get
            {
                InitOrganizations(false);
                return this.organizations;
            }
        }

        public Organization GetPrimaryOrganization(string userId, bool getFirstIfNotBelong)
        {
            InitUsers(false);
            InitOrganizations(false);

            if (!this.users.Contains(userId)) return null;

            User user = this.users[userId];

            if (this.organizations.Contains(user.PrimaryOrganizationId))
            {
                return this.organizations[user.PrimaryOrganizationId];
            }


            foreach (string orgId in user.OrganizationIds)
            {
                if (this.organizations.Contains(orgId))
                {
                    return this.organizations[orgId];
                }
            }

            if(this.rootOrganizations.Count > 0)
            {
                foreach (Organization org in this.rootOrganizations)
                {
                    if (org.UserIds.Contains(userId)) return org;
                }
            }

            if (getFirstIfNotBelong && this.rootOrganizations.Count > 0)
            {
                return this.rootOrganizations[0];
            }

            return null;
        }

        protected void InitOrganizations(bool force)
        {
            if (!force && this.organizations != null) return;

            XmlElement resultNode = this.App.QueryItems("Base", "BaseGetOrganizationVersions", "BaseGetOrganizationsById", "organization_id", "organization_item");
            XmlNodeList orgNodeList = resultNode.SelectNodes("//organization[@name]");

            this.organizations = new OrganizationCollection();
            this.rootOrganizations = new OrganizationCollection();

            foreach (XmlNode orgNode in orgNodeList)
            {
                Organization org = new Organization(orgNode);
                this.organizations.Add(org);

                if (string.IsNullOrEmpty(org.ParentOrganizationId))
                {
                    this.rootOrganizations.Add(org);
                }
                else
                {
                    this.hierarchical = true;
                }
            }
        }
    }
}
