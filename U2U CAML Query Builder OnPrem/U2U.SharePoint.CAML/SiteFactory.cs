namespace U2U.SharePoint.CAML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    public static class SiteFactory
    {
        public static ISite Create(QueryInfo queryInfo)
        {

            var instance = new CSOM.CSOMSite(queryInfo);
            return instance as ISite;
        }




    }
}

