namespace U2U.SharePoint.CAML
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// 
    /// </summary>
    public interface ISite
    {
        //string Title { get; }
        Task<string> GetTitle();

        string SiteUrl { get; set; }

        bool IsClient { get; set; }

        Task<Collection<ListInfo>> GetLists();

        Task<Collection<QueryInfo>> GetSites();

        Task<Collection<FieldObject>> GetFields(string listGuid);

        Task<Collection<ViewObject>> GetViews(string listName);

        Task<Collection<String>> GetLookupValues(FieldObject field);

        DataTable GetListItems(string listName, XmlDocument queryDoc);
    }
}
