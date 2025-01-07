namespace U2U.SharePoint.CAML
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Xml;
    using U2U.SharePoint.CAML.Enumerations;

    public class QueryInfo : ICloneable, INotifyPropertyChanged, IEquatable<QueryInfo>
    {
        public QueryInfo()
        { }

        public string Filename { get; set; }

        public string Title { get; set; }

        public string SharePointUri { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Domain { get; set; }

        public bool IsO365Connection { get; set; }

        public bool IsCustomCredentials { get; set; }

        public bool HasCustomCredentials { get; set; }

        public bool IsQueryByName { get; set; }

        public string Since { get; set; }

        private string changeToken;

        public string ChangeToken
        {
            get { return changeToken; }
            set
            {
                if (changeToken != value)
                {
                    changeToken = value;
                    OnPropertyChanged("ChangeToken");
                }
            }
        }

        public CamlTypes QueryType { get; set; }

        public XmlDocument CamlDocument { get; set; }

        public ListInfo List { get; set; }

        public ISite Site { get; set; }

        public void Load(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename");
            }

            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("The file does not exist", filename);
            }

            Filename = filename;
            using (TextReader sr = new StreamReader(filename))
            {
                string uri = sr.ReadLine();
                if (string.IsNullOrEmpty(uri))
                {
                    throw new ApplicationException("The file has an incorrect format.");
                }

                // this string contains a letter s(erver) or c(lient) and the uri
                string connectiontype = uri.Substring(0, uri.IndexOf("|"));
                SharePointUri = uri.Substring(uri.IndexOf("|") + 1, uri.Length - uri.IndexOf("|") - 1);
                IsO365Connection = (connectiontype != "s");

                // check the user credentials
                string credentialString = sr.ReadLine();
                if (!string.IsNullOrEmpty(credentialString))
                {
                    string[] credentials = credentialString.Split('|');
                    if (credentials.Length == 3)
                    {
                        IsCustomCredentials = true;
                        UserName = credentials[0];
                        Password = U2U.UtilityFunctions.Encryption.DecryptData(credentials[1]);
                        Domain = credentials[2];
                    }
                }
                Site = SiteFactory.Create(this);

                string list = sr.ReadLine();
                string[] parts = list.Split(new char[] { '|' });
                if (parts.Length == 3)
                {
                    QueryType = (CamlTypes)Enum.Parse(typeof(CamlTypes), parts[2], true);
                    List = new ListInfo() { Id = parts[1], Name = parts[0] };
                }

                // fill Query by name or id
                bool isQueryByName = true;
                string text = sr.ReadLine();
                if (!string.IsNullOrEmpty(text))
                {
                    bool.TryParse(text, out isQueryByName);
                    IsQueryByName = isQueryByName;
                }

                // read the extra params
                string extraParam = sr.ReadLine();

                // fill the treeview and the caml document
                text = sr.ReadLine();
                if (!string.IsNullOrEmpty(text))
                {
                    CamlDocument = new XmlDocument();
                    CamlDocument.LoadXml(text);
                }
            }
        }

        public void Save(string filename)
        {
            using (TextWriter wr = new StreamWriter(filename, false))
            {
                if (!string.IsNullOrEmpty(SharePointUri))
                {
                    wr.WriteLine("{0}|{1}", IsO365Connection ? "c" : "s", SharePointUri);
                }
                else
                {
                    wr.WriteLine("");
                }

                // Write credentials.
                if (HasCustomCredentials)
                {
                    if (!string.IsNullOrEmpty(UserName))
                    {
                        wr.WriteLine("{0}|{1}|{2}", UserName, U2U.UtilityFunctions.Encryption.EncryptData(Password), Domain);
                    }
                }
                else
                {
                    wr.WriteLine("");
                }

                // Write listinfo
                if (List != null && !string.IsNullOrEmpty(List.Name) && !string.IsNullOrEmpty(List.Id))
                {
                    wr.WriteLine("{0}|{1}|{2}", List.Name, List.Id, QueryType.ToString());
                }
                else
                {
                    wr.WriteLine("");
                }

                // Write IsQueryByName
                wr.WriteLine(IsQueryByName.ToString());

                // write the extra data
                wr.WriteLine();

                // write the query
                if (CamlDocument != null)
                {
                    XmlDocument tempdoc = new XmlDocument();
                    tempdoc.PreserveWhitespace = false;
                    try
                    {
                        tempdoc.LoadXml(CamlDocument.InnerXml);
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException("The CAML is not valid xml", ex);
                    }
                    wr.WriteLine(tempdoc.InnerXml);
                }
                else
                {
                    wr.WriteLine("");
                }
            }
        }

        #region ICloneable Members

        public object Clone()
        {
            return new QueryInfo()
            {
                Title = this.Title,
                SharePointUri = this.SharePointUri,
                UserName = this.UserName,
                Password = this.Password,
                Domain = this.Domain,
                IsO365Connection = this.IsO365Connection,
                IsCustomCredentials = this.IsCustomCredentials,
                HasCustomCredentials = this.HasCustomCredentials,
                IsQueryByName = this.IsQueryByName,
                List = this.List != null ? new ListInfo() { Id = this.List.Id, Name = this.List.Name, ImageUrl = this.List.ImageUrl } : null,
                Site = this.Site != null ? SiteFactory.Create(this) : null
            };
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region IEquatable<QueryInfo> Members

        public bool Equals(QueryInfo other)
        {
            return other != null
                && SharePointUri.Equals(other.SharePointUri)
                && IsO365Connection == other.IsO365Connection
                && IsCustomCredentials == other.IsCustomCredentials
                && UserName.Equals(other.UserName)
                && Password.Equals(other.Password)
                && Domain.Equals(other.Domain);
        }

        #endregion
    }
}
