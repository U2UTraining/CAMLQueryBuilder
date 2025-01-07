using System;
using U2U.SharePoint.CAML.Enumerations;

namespace U2U.Constants
{
    /// <summary>
    /// Summary description for ConstantUserControls.
    /// </summary>
    /// 
    public class CamlBuilder
    {
        public const string APP_TITLE = "U2U CAML Builder";
        public const string APP_CONFIG_DIR = "U2U";
        public const string APP_CONFIG_FILE = "CamlCreatorConfig.txt";
    }

    public class UserControls
    {
        public class SharePointHierarchy
        {
            public class MenuItems
            {
                public const string Query = "Query";
                public const string GetListItems = "GetListItems";
                public const string GetListItemChanges = "GetListItemChanges";
                public const string GetListItemChangesSinceToken = "GetListItemChangesSinceToken";
                public const string UpdateListItems = "UpdateListItems";

                public static CamlTypes GetQueryType(string selectedMenuItem)
                {
                    CamlTypes queryType = CamlTypes.Query;
                    switch (selectedMenuItem)
                    {
                        case UserControls.SharePointHierarchy.MenuItems.Query:
                            {
                                queryType = CamlTypes.Query;
                                break;
                            }
                        case U2U.Constants.UserControls.SharePointHierarchy.MenuItems.GetListItems:
                            {
                                queryType = CamlTypes.GetListItems;
                                break;
                            }
                        case U2U.Constants.UserControls.SharePointHierarchy.MenuItems.GetListItemChanges:
                            {
                                queryType = CamlTypes.GetListItemChanges;
                                break;
                            }
                        case U2U.Constants.UserControls.SharePointHierarchy.MenuItems.GetListItemChangesSinceToken:
                            {
                                queryType = CamlTypes.GetListItemChangesSinceToken;
                                break;
                            }
                        case U2U.Constants.UserControls.SharePointHierarchy.MenuItems.UpdateListItems:
                            {
                                queryType = CamlTypes.UpdateListItems;
                                break;
                            }
                    }

                    return queryType;
                }

            }

            public class Nodes
            {
                public const string SubWebs = "Sub webs";
                public const string Lists = "Lists";
                public const string Fields = "Fields";
                public const string Views = "Views";
            }
        }

        public class CamlEditor
        {
            public class TabControl
            {
                public const int EditorTab = 0;
                public const int ParametersTab = 1;
                public const int ResultTab = 2;
            }

        }

        public class UpdateListItemsControl
        {
            public class TabControl
            {
                public const int BatchTab = 0;
                public const int MethodTab = 1;
            }
        }
    }
}
