using Microsoft.SharePoint.Client;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using U2U.SharePoint.CAML.O365Helpers;

namespace U2U.SharePoint.CAML.CSOM
{
    //TODO : check if ClientCOntext is disposed !!
    public class CSOMSite : ISite
    {
        public CSOMSite(string siteUrl)
        {
            this.SiteUrl = siteUrl;
        }

        public CSOMSite(QueryInfo queryInfo)
        {
            SiteUrl = queryInfo.SharePointUri;
            IsClient = true;
        }

        private string title;

        public async Task<string> GetTitle()
        {
            if (string.IsNullOrEmpty(this.title))
            {
                ClientContext ctx = new ClientContext(this.SiteUrl);
                Web web = await GetWeb(ctx).ConfigureAwait(false);
                ctx.Load(web, w => w.Title);
                await ctx.ExecuteQueryAsync().ConfigureAwait(false);
                this.title = web.Title;
                ctx.Dispose();
            }

            return this.title;

        }

        private async Task<Web> GetWeb(ClientContext ctx)
        {
            await MSALClaimsHelper.Init(this.SiteUrl).ConfigureAwait(false);
            ctx.ExecutingWebRequest += MSALClaimsHelper.clientContext_ExecutingWebRequest;
            Web web = ctx.Web;
            return web;
        }

        public string SiteUrl { get; set; }

        public bool IsClient { get; set; }

        public async Task<Collection<ListInfo>> GetLists()
        {
            ClientContext ctx = new ClientContext(this.SiteUrl);
            Web web = await GetWeb(ctx).ConfigureAwait(false);
            var lists = web.Lists;
            ctx.Load(lists, ls => ls.Include(l => l.Id, l => l.Title, l => l.ImageUrl));//, ls => ls.Include(l=>l.Id,l=>l.Title,l=>l.ImageUrl)
            await ctx.ExecuteQueryAsync().ConfigureAwait(false);

            ctx.Dispose();

            var result = lists.AsEnumerable().Select(l => new ListInfo()
            {
                Id = l.Id.ToString(),
                Name = l.Title,
                ImageUrl = l.ImageUrl
            });

            return new Collection<ListInfo>(result.ToList());

        }

        public async Task<System.Collections.ObjectModel.Collection<QueryInfo>> GetSites()
        {
            ClientContext ctx = new ClientContext(this.SiteUrl);
            Web web = await GetWeb(ctx).ConfigureAwait(false);
            var webs = web.Webs;
            ctx.Load(webs, ws => ws.Include(w => w.Title, w => w.Url));
            await ctx.ExecuteQueryAsync().ConfigureAwait(false);

            ctx.Dispose();

            var result = webs.AsEnumerable().Select(w => new QueryInfo()
            {
                Title = w.Title,
                SharePointUri = w.Url
            });

            return new Collection<QueryInfo>(result.ToList());


        }

        public async Task<System.Collections.ObjectModel.Collection<FieldObject>> GetFields(string listGuid)
        {
            ClientContext ctx = new ClientContext(this.SiteUrl);
            Web web = await GetWeb(ctx).ConfigureAwait(false);

            List l = web.Lists.GetById(new Guid(listGuid));
            var q = from f in l.Fields
                    where !f.Hidden
                    select f;

            var result = ctx.LoadQuery(q);
            await ctx.ExecuteQueryAsync().ConfigureAwait(false);

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
                        choices += string.Format("<CHOICE>{0}</CHOICE>", ch);
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

        public async Task<System.Collections.ObjectModel.Collection<ViewObject>> GetViews(string listName)
        {
            //TODO : check: must return DisplayName and internalname -> no such things
            ClientContext ctx = new ClientContext(this.SiteUrl);
            Web web = await GetWeb(ctx).ConfigureAwait(false);
            List l = web.Lists.GetByTitle(listName);
            var views = l.Views;
            ctx.Load(views, vs => vs.Include(v => v.Title));
            await ctx.ExecuteQueryAsync().ConfigureAwait(false);
            ctx.Dispose();

            return new Collection<ViewObject>(views.AsEnumerable().Select(v => new ViewObject(v.Title, v.Title)).ToList());
        }

        //TODO: probably needs to return a list of lookuovalues
        public async Task<System.Collections.ObjectModel.Collection<string>> GetLookupValues(FieldObject field)
        {
            ClientContext ctx = new ClientContext(this.SiteUrl);
            Web web = await GetWeb(ctx).ConfigureAwait(false);
            List l = web.Lists.GetById(new Guid(field.LookupList));
            var values = l.GetItems(CamlQuery.CreateAllItemsQuery());
            ctx.Load(values);//, xs=>xs.Include(x=>x[field.ShowField]));
            await ctx.ExecuteQueryAsync().ConfigureAwait(false);

            ctx.Dispose();

            var results = values.AsEnumerable().Where(x => x[field.ShowField] != null).Select(x => x[field.ShowField].ToString()).ToList();

            return new Collection<string>(results);
        }

        //TODO : get rid of datatable later...
        public System.Data.DataTable GetListItems(string listName, System.Xml.XmlDocument queryDoc)
        {
            ClientContext ctx = new ClientContext(this.SiteUrl);
            Web web = GetWeb(ctx).Result;
            List list = web.Lists.GetByTitle(listName);
            CamlQuery q;
            if (!string.IsNullOrEmpty(queryDoc.InnerXml))
            {
                if (queryDoc.InnerXml.Contains("GetListItems"))
                {
                    q = new CamlQuery() { ViewXml = queryDoc.InnerXml.Replace("GetListItems", "View") };
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
                            dr[field.ColumnName] = ((FieldLookupValue)item[field.ColumnName]).LookupValue;
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



        //public System.Data.DataTable GetListItems(string listName, System.Xml.XmlDocument queryDoc, List<CamlParameter> parameters)
        //{
        //    throw new NotImplementedException();
        //}

        //public System.Data.DataTable GetListItemChanges(string listName, string since, System.Xml.XmlDocument queryDoc)
        //{
        //    throw new NotImplementedException();
        //}

        //public System.Data.DataTable GetListItemChanges(string listName, string since, System.Xml.XmlDocument queryDoc, List<CamlParameter> parameters)
        //{
        //    throw new NotImplementedException();
        //}

        //public System.Data.DataTable GetListItemChangesSinceToken(string listName, ref string sinceToken, System.Xml.XmlDocument queryDoc)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
