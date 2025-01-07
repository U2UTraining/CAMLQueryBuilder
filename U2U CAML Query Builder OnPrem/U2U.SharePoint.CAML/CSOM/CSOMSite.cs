using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Wictor.Office365;

namespace U2U.SharePoint.CAML.CSOM
{
    //TODO : check if ClientCOntext is disposed !!
    public class CSOMSite : ISite, IDisposable
    {
        public CSOMSite(string siteUrl)
        {
            this.SiteUrl = siteUrl;
        }

        public CSOMSite(QueryInfo queryInfo)
        {
            SiteUrl = queryInfo.SharePointUri;
            userName = queryInfo.UserName;
            password = queryInfo.Password;
            domain = queryInfo.Domain;
            IsOffice365 = queryInfo.IsO365Connection;
            IsClient = true;
        }

        private string userName;

        private string password;

        private string domain;

        public bool IsPublic { get; set; }

        private ICredentials credentials;

        internal ICredentials Credentials
        {
            get
            {
                if (credentials == null)
                {
                    if (string.IsNullOrEmpty(userName))
                    {
                        credentials = CredentialCache.DefaultCredentials;
                    }
                    else if (string.IsNullOrEmpty(domain))
                    {
                        credentials = new NetworkCredential(userName, password);
                    }
                    else
                    {
                        credentials = new NetworkCredential(userName, password, domain);

                    }
                }

                return credentials;
            }
        }

        private string title;

        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(this.title))
                {
                    ClientContext ctx = new ClientContext(this.SiteUrl);
                    Web web = GetWeb(ctx);
                    ctx.Load(web, w => w.Title);
                    ctx.ExecuteQuery();
                    this.title = web.Title;
                    ctx.Dispose();
                }

                return this.title;
            }
        }

        private Web GetWeb(ClientContext ctx)
        {
            if (this.IsOffice365)
            {
                MsOnlineClaimsHelper helper = new MsOnlineClaimsHelper(this.SiteUrl, this.userName, this.password);
                ctx.ExecutingWebRequest += helper.clientContext_ExecutingWebRequest;
                Web web = ctx.Web;
                return web;
            }
            else
            {
                ctx.Credentials = this.Credentials;
                Web web = ctx.Web;
                return web;
            }          	        
            
        }


        public string SiteUrl { get; set; }

        public bool IsClient { get; set; }

        public bool IsOffice365 { get; set; }

        public Collection<ListInfo> GetLists()
        {
            ClientContext ctx = new ClientContext(this.SiteUrl);
            Web web=GetWeb(ctx);
            var lists = web.Lists;
            ctx.Load(lists, ls => ls.Include(l => l.Id, l => l.Title, l => l.ImageUrl));//, ls => ls.Include(l=>l.Id,l=>l.Title,l=>l.ImageUrl)
            ctx.ExecuteQuery();

            ctx.Dispose();

            var result = lists.AsEnumerable().Select(l => new ListInfo()
            {
                Id = l.Id.ToString(),
                Name = l.Title,
                ImageUrl = l.ImageUrl
            });

            return new Collection<ListInfo>(result.ToList());

        }

        public System.Collections.ObjectModel.Collection<QueryInfo> GetSites()
        {
            ClientContext ctx = new ClientContext(this.SiteUrl);
            Web web = GetWeb(ctx);
            var webs = web.Webs;
            ctx.Load(webs, ws => ws.Include(w => w.Title, w => w.Url));
            ctx.ExecuteQuery();

            ctx.Dispose();

            var result = webs.AsEnumerable().Select(w => new QueryInfo()
            {
                Title = w.Title,
                SharePointUri = w.Url
            });

            return new Collection<QueryInfo>(result.ToList());


        }

        public System.Collections.ObjectModel.Collection<FieldObject> GetFields(string listGuid)
        {
            ClientContext ctx = new ClientContext(this.SiteUrl);
            Web web = GetWeb(ctx);

            List l = web.Lists.GetById(new Guid(listGuid));
            var q = from f in l.Fields
                    where !f.Hidden
                    select f;

            var result = ctx.LoadQuery(q);
            ctx.ExecuteQuery();

            ctx.Dispose();

            var fields = new Collection<FieldObject>();

            foreach (var item in result)
            {
                FieldObject o = new FieldObject(item.Title, item.Id, item.InternalName, item.TypeAsString);
                if (item is FieldLookup)
                {
                    FieldLookup lookup = item as FieldLookup;
                    o.LookupList = lookup.LookupList;
                    o.ShowField = lookup.LookupField;
                }
                if (item is FieldChoice)
                {
                    FieldChoice choice = item as FieldChoice;
                    string choices = "<CHOICES>";
                    foreach (var ch in choice.Choices)
                    {
                        choices += string.Format("<CHOICE>{0}</CHOICE>",ch);
                    }
                    choices += "</CHOICES>";

                    o.ChoiceList = choices;
                    o.DefaultChoice = choice.DefaultValue;
                }
                fields.Add(o);
            }

            //return new Collection<FieldObject>(result.AsEnumerable().Select(f => new FieldObject(f.Title, f.Id, f.InternalName, f.TypeAsString)).ToList());
            return fields;
        }

        public System.Collections.ObjectModel.Collection<ViewObject> GetViews(string listName)
        {
            //TODO : check: must return DisplayName and internalname -> no such things
            ClientContext ctx = new ClientContext(this.SiteUrl);
            Web web = GetWeb(ctx);
            List l = web.Lists.GetByTitle(listName);
            var views = l.Views;
            ctx.Load(views, vs => vs.Include(v => v.Title));
            ctx.ExecuteQuery();
            ctx.Dispose();

            return new Collection<ViewObject>(views.AsEnumerable().Select(v => new ViewObject(v.Title, v.Title)).ToList());
        }

        //TODO: probably needs to return a list of lookuovalues
        public System.Collections.ObjectModel.Collection<string> GetLookupValues(FieldObject field)
        {
            ClientContext ctx = new ClientContext(this.SiteUrl);
            Web web = GetWeb(ctx);
            List l = web.Lists.GetById(new Guid(field.LookupList));
            var values = l.GetItems(CamlQuery.CreateAllItemsQuery());
            ctx.Load(values);//, xs=>xs.Include(x=>x[field.ShowField]));
            ctx.ExecuteQuery();

            ctx.Dispose();

            var results = values.AsEnumerable().Where(x => x[field.ShowField] != null).Select(x => x[field.ShowField].ToString()).ToList();

            return new Collection<string>(results);
        }

        //TODO : get rid of datatable later...
        public System.Data.DataTable GetListItems(string listName, System.Xml.XmlDocument queryDoc)
        {
            ClientContext ctx = new ClientContext(this.SiteUrl);
            Web web = GetWeb(ctx);
            List list = web.Lists.GetByTitle(listName);
            CamlQuery q;
            if (!string.IsNullOrEmpty(queryDoc.InnerXml))
            {
                if (queryDoc.InnerXml.Contains("GetListItems"))
                {
                    q = new CamlQuery() { ViewXml = queryDoc.InnerXml.Replace("GetListItems","View") };
                }
                else
                {
                    q = new CamlQuery() { ViewXml = string.Format("<View>{0}</View>", queryDoc.InnerXml) };
                }
                
            }
            else
            {
                q = CamlQuery.CreateAllItemsQuery();
            }

            var listItems = list.GetItems(q);
            ctx.Load(list, l => l.Fields);
            ctx.Load(listItems);
            ctx.ExecuteQuery();

            ctx.Dispose();
            DataTable dt = CreateDataTable(list, listItems);

            return dt;

        }

        private DataTable CreateDataTable(List list, ListItemCollection listItems)
        {

            DataTable dt = new DataTable();
            var firstItem = listItems.FirstOrDefault();
            if (firstItem != null)
            {
                foreach (var item in firstItem.FieldValues.Keys)
                {
                    dt.Columns.Add(item);
                }
            }
            else
            {
                foreach (var field in list.Fields)
                {
                    dt.Columns.Add(field.InternalName);
                }
            }
            

            foreach (var item in listItems)
            {
                DataRow dr = dt.NewRow();
                foreach (DataColumn field in dt.Columns)
                {
                    if (item.FieldValues.ContainsKey(field.ColumnName) && item[field.ColumnName] != null)
                    {
                        if (item[field.ColumnName] is FieldLookupValue)
                        {
                            dr[field.ColumnName] = ((FieldLookupValue) item[field.ColumnName]).LookupValue;
                        }
                        else
                        {
                            dr[field.ColumnName] = item[field.ColumnName].ToString();
                        }
                    }
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }



        public System.Data.DataTable GetListItems(string listName, System.Xml.XmlDocument queryDoc, List<CamlParameter> parameters)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetListItemChanges(string listName, string since, System.Xml.XmlDocument queryDoc)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetListItemChanges(string listName, string since, System.Xml.XmlDocument queryDoc, List<CamlParameter> parameters)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetListItemChangesSinceToken(string listName, ref string sinceToken, System.Xml.XmlDocument queryDoc)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
