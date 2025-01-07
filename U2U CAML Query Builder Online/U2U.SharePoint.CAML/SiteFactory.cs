namespace U2U.SharePoint.CAML
{
    public static class SiteFactory
    {
        public static ISite Create(QueryInfo queryInfo)
        {

            var instance = new CSOM.CSOMSite(queryInfo);
            return instance as ISite;
        }




    }
}

