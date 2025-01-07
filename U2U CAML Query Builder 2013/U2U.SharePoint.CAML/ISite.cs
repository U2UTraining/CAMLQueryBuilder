namespace U2U.SharePoint.CAML
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Collections.Generic;
    using System.Xml;

    /// <summary>
    /// 
    /// </summary>
    public interface ISite
    {
        string Title { get; }

        string SiteUrl { get; set; }

        bool IsClient { get; set; }

        Collection<ListInfo> GetLists();

        Collection<QueryInfo> GetSites();

        Collection<FieldObject> GetFields(string listGuid);

        Collection<ViewObject> GetViews(string listName);

        Collection<String> GetLookupValues(FieldObject field);

        DataTable GetListItems(string listName, XmlDocument queryDoc);

        DataTable GetListItems(string listName, XmlDocument queryDoc, List<CamlParameter> parameters);

        DataTable GetListItemChanges(string listName, string since, XmlDocument queryDoc);

        DataTable GetListItemChanges(string listName, string since, XmlDocument queryDoc, List<CamlParameter> parameters);

        DataTable GetListItemChangesSinceToken(string listName, ref string sinceToken, XmlDocument queryDoc);
    }
}
