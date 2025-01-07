namespace Caml.Constants
{
    /// <summary>
    /// Summary description for Constants.
    /// </summary>
    public class CamlEnumerations
    {
        public const string CamlFieldTypeEnumeration = "FieldTypeEnum";
        public const string CamlOperatorEnumeration = "CamlOperatorEnum";
        public const string CamlCombinerEnumeration = "CamlCombinerEnum";
    }

    public class Query
    {
        public const string Tag = "Query";

        public class Where
        {
            public const string Tag = "Where";
            public const string DateRangesOverlap = "DateRangesOverlap";

            public class FieldRef
            {
                public const string Tag = "FieldRef";
                public class Attributes
                {
                    public const string ID = "ID";
                    public const string Name = "Name";
                }
            }
            public class ValueType
            {
                public const string Tag = "Value";
                public class Attributes
                {
                    public const string Type = "Type";
                    public const string IncludeTimeValue = "IncludeTimeValue";
                }
            }
        }

        public class OrderBy
        {
            public const string Tag = "OrderBy";

            public class FieldRef
            {
                public const string Tag = "FieldRef";
                public class Attributes
                {
                    public const string ID = "ID";
                    public const string Name = "Name";
                    public const string Ascending = "Ascending";
                }
            }
        }

    }

    public class ViewFields
    {
        public const string Tag = "ViewFields";

        public class FieldRef
        {
            public const string Tag = "FieldRef";
            public class Attributes
            {
                public const string Name = "Name";
                public const string ID = "ID";
            }
        }
    }

    public class QueryOptions
    {
        public const string Tag = "QueryOptions";
        public const string IncludedMandatoryColumns = "IncludeMandatoryColumns";
        public const string CalendarDate = "CalendarDate";
        public const string DatesInUtc = "DateInUtc";
        public const string Folder = "Folder";
        public const string Paging = "Paging";
        public const string MeetingInstanceID = "MeetingInstanceID";
        public const string ViewAttributes = "ViewAttributes";
        public const string Scope = "Scope";
        public const string ExpandUserField = "ExpandUserField";
        public const string ExpandRecurrence = "ExpandRecurrence";
        public const string RecurrenceOrderBy = "RecurrenceOrderBy";
        public const string ExtraIds = "ExtraIds";
        public const string IncludeAttachmentUrls = "IncludeAttachmentUrls";
        public const string IncludeAttachmentVersion = "IncludeAttachmentVersion";
        public const string IncludeAllUserPermissions = "IncludeAllUserPermissions";
        public const string IncludePermissions = "IncludePermissions";
        public const string IndividualProperties = "IndividualProperties";
        public const string ItemIDQuery = "ItemIDQuery";
        public const string OptimizeFor = "OptimizeFor";
        public const string RowLimit = "RowLimit";
    }

    public class Contains
    {
        public const string Tag = "Contains";

        public class FieldRef
        {
            public const string Tag = "FieldRef";
            public class Attributes
            {
                public const string Name = "Name";
                public const string ID = "ID";
            }
        }
        public class ValueType
        {
            public const string Tag = "Value";
            public class Attributes
            {
                public const string Type = "Type";
            }
        }
    }

    public class Batch
    {
        public const string Tag = "Batch";
        public const string OnError = "OnError";
        public const string ListVersion = "ListVersion";
        public const string PreCalc = "PreCalc";
        public const string RootFolder = "RootFolder";
        public const string ViewName = "ViewName";

        public class Method
        {
            public const string Tag = "Method";
            public const string ID = "ID";

            public class Command
            {
                public const string Tag = "Cmd";
                public const string New = "New";
                public const string Update = "Update";
                public const string Delete = "Delete";
            }

            public class Field
            {
                public const string Tag = "Field";
                public const string Name = "Name";
            }
        }
    }
}