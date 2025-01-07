using System;
using System.Collections.Generic;
using System.Xml;
using U2U.SharePoint.CAML.Enumerations;

namespace U2U.SharePoint.CAML
{
    /// <summary>
    /// Summary description for Builder.
    /// </summary>
    public class Builder
    {
        private bool isFieldRefName = true;
        private XmlDocument camlDocument = null;
        private XmlNode rootNode = null;
        private XmlNode queryNode = null;
        private XmlNode orderByNode = null;
        private XmlNode whereNode = null;
        private XmlNode queryOptionsNode = null;
        private XmlNode viewFieldsNode = null;
        private XmlNode containsNode = null;
        private XmlNode batchNode = null;
        private U2U.SharePoint.CAML.Enumerations.CamlTypes camlType;

        public Builder(U2U.SharePoint.CAML.Enumerations.CamlTypes camlType)
        {
            this.camlType = camlType;
            camlDocument = new XmlDocument();
            switch (camlType)
            {
                case U2U.SharePoint.CAML.Enumerations.CamlTypes.Query:
                    {
                        rootNode = queryNode = camlDocument.CreateElement(Caml.Constants.Query.Tag);
                        camlDocument.AppendChild(queryNode);
                        break;
                    }
                case U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItems:
                    {
                        rootNode = camlDocument.CreateElement(camlType.ToString());
                        camlDocument.AppendChild(rootNode);
                        queryNode = camlDocument.CreateElement(Caml.Constants.Query.Tag);
                        rootNode.AppendChild(queryNode);
                        viewFieldsNode = camlDocument.CreateElement(Caml.Constants.ViewFields.Tag);
                        rootNode.AppendChild(viewFieldsNode);
                        queryOptionsNode = camlDocument.CreateElement(Caml.Constants.QueryOptions.Tag);
                        rootNode.AppendChild(queryOptionsNode);

                        break;
                    }
                case U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItemChanges:
                    {
                        rootNode = camlDocument.CreateElement(camlType.ToString());
                        camlDocument.AppendChild(rootNode);
                        break;
                    }
                case U2U.SharePoint.CAML.Enumerations.CamlTypes.UpdateListItems:
                    {
                        rootNode = camlDocument.CreateElement(camlType.ToString());
                        camlDocument.AppendChild(rootNode);
                        batchNode = camlDocument.CreateElement(Caml.Constants.Batch.Tag);
                        UpdateBatchNode(Caml.Constants.Batch.PreCalc, "TRUE");
                        rootNode.AppendChild(batchNode);

                        break;
                    }
            }
        }

        public Builder(XmlDocument camlDocument)
        {
            this.camlDocument = camlDocument;
            GetCamlNodes();
        }

        #region Properties
        // TODO: add set properties but those should be validated against an xsd schema
        public U2U.SharePoint.CAML.Enumerations.CamlTypes CamlType
        {
            get { return camlType; }
            set { camlType = value; }
        }

        public bool IsQueryByFieldName
        {
            get { return isFieldRefName; }
            set
            {
                isFieldRefName = value;
                CheckFieldRefs();
            }
        }

        public XmlDocument CamlDocument
        {
            get { return camlDocument; }
        }

        public XmlNode OrderByNode
        {
            get
            {
                if (orderByNode == null && camlDocument != null)
                {
                    orderByNode = camlDocument.CreateElement(Caml.Constants.Query.OrderBy.Tag);
                    QueryNode.AppendChild(orderByNode);
                }

                return orderByNode;
            }
        }

        public XmlNode WhereNode
        {
            get
            {
                if (whereNode == null && camlDocument != null)
                {
                    whereNode = camlDocument.CreateElement(Caml.Constants.Query.Where.Tag);
                    QueryNode.AppendChild(whereNode);
                }
                return whereNode;
            }
        }

        public XmlNode QueryNode
        {
            get
            {
                if (queryNode == null && camlDocument != null)
                {
                    queryNode = camlDocument.CreateElement(Caml.Constants.Query.Tag);
                    switch (camlType)
                    {
                        case U2U.SharePoint.CAML.Enumerations.CamlTypes.Query:
                            {
                                camlDocument.AppendChild(queryNode);
                                break;
                            }
                        case U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItems:
                        case U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItemChangesSinceToken:
                        case U2U.SharePoint.CAML.Enumerations.CamlTypes.UpdateListItems:
                            {
                                RootNode.AppendChild(queryNode);
                                break;
                            }

                    }
                }
                return queryNode;
            }
        }

        public XmlNode RootNode
        {
            get
            {
                if (rootNode == null && camlDocument != null)
                {
                    rootNode = camlDocument.CreateElement(camlType.ToString());
                    camlDocument.AppendChild(rootNode);
                }
                return rootNode;
            }
        }

        public XmlNode ViewFieldsNode
        {
            get
            {
                if (viewFieldsNode == null)
                {
                    viewFieldsNode = camlDocument.CreateElement(Caml.Constants.ViewFields.Tag);
                    RootNode.AppendChild(viewFieldsNode);
                }
                return viewFieldsNode;
            }
        }

        public XmlNode QueryOptionsNode
        {
            get
            {
                if (queryOptionsNode == null)
                {
                    queryOptionsNode = camlDocument.CreateElement(Caml.Constants.QueryOptions.Tag);
                    RootNode.AppendChild(queryOptionsNode);
                }
                return queryOptionsNode;
            }
        }

        public XmlNode ContainsNode
        {
            get
            {
                if (containsNode == null)
                {
                    containsNode = camlDocument.CreateElement(Caml.Constants.Contains.Tag);
                    RootNode.AppendChild(containsNode);
                }
                return containsNode;
            }
        }

        public bool HasContainsNode { get { return containsNode != null; } }

        public bool HasWhereNode { get { return whereNode != null; } }

        public bool HasViewFieldsNode { get { return viewFieldsNode != null; } }

        public XmlNode BatchNode
        {
            get
            {
                if (batchNode == null && camlDocument != null)
                {
                    batchNode = camlDocument.CreateElement(Caml.Constants.Batch.Tag);
                    UpdateBatchNode(Caml.Constants.Batch.PreCalc, "TRUE");
                    rootNode.AppendChild(batchNode);
                }
                return batchNode;
            }
        }

        #endregion

        private void CheckFieldRefs()
        {
            // TODO check the Query node and the ViewFields node
        }

        public void Clear()
        {
            if (camlType == U2U.SharePoint.CAML.Enumerations.CamlTypes.Query)
            {
                if (queryNode != null)
                    camlDocument.RemoveChild(queryNode);
            }

            // this will only be executed in case of other CAML types
            if (rootNode != null && queryNode != null && rootNode != queryNode)
                rootNode.RemoveChild(queryNode);
            if (rootNode != null && queryOptionsNode != null)
                rootNode.RemoveChild(queryOptionsNode);
            if (rootNode != null && containsNode != null)
                rootNode.RemoveChild(containsNode);
            if (rootNode != null && viewFieldsNode != null)
                rootNode.RemoveChild(viewFieldsNode);
            if (rootNode != null && batchNode != null)
                rootNode.RemoveChild(batchNode);

            queryNode = null;
            orderByNode = null;
            whereNode = null;
            queryOptionsNode = null;
            containsNode = null;
            viewFieldsNode = null;
            batchNode = null;

            if (rootNode == null && camlDocument.FirstChild != null && camlDocument.FirstChild.ChildNodes.Count > 0)
            {
                // this means the root node has not yet been filled after a query has been opened from a file
                camlDocument.FirstChild.RemoveAll();
            }
        }

        public void RemoveOrderByNode()
        {
            if (orderByNode != null && queryNode != null)
            {
                orderByNode.RemoveAll();
                queryNode.RemoveChild(orderByNode);
                orderByNode = null;
            }
        }

        public void RemoveWhereNode()
        {
            if (whereNode != null && queryNode != null)
            {
                whereNode.RemoveAll();
                queryNode.RemoveChild(whereNode);
                whereNode = null;
            }
        }

        public void RemoveContainsNode()
        {
            if (containsNode != null)
            {
                containsNode.RemoveAll();
                RootNode.RemoveChild(containsNode);
                containsNode = null;
            }
        }

        public void RemoveQueryNode()
        {
            if (queryNode != null)
            {
                queryNode.RemoveAll();
                RootNode.RemoveChild(queryNode);
                queryNode = null;
            }
        }


        private void GetCamlNodes()
        {
            XmlNode rootNode = camlDocument.FirstChild;
            switch (rootNode.Name)
            {
                case Caml.Constants.Query.Tag:
                    {
                        camlType = U2U.SharePoint.CAML.Enumerations.CamlTypes.Query;
                        queryNode = camlDocument.SelectSingleNode(Caml.Constants.Query.Tag);
                        whereNode = camlDocument.SelectSingleNode(Caml.Constants.Query.Tag + "/" + Caml.Constants.Query.Where.Tag);
                        orderByNode = camlDocument.SelectSingleNode(Caml.Constants.Query.Tag + "/" + Caml.Constants.Query.OrderBy.Tag);
                        break;
                    }
                case "GetListItems":
                    {
                        camlType = U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItems;
                        queryNode = camlDocument.SelectSingleNode("//" + Caml.Constants.Query.Tag);
                        queryOptionsNode = camlDocument.SelectSingleNode("//" + Caml.Constants.QueryOptions.Tag);
                        viewFieldsNode = camlDocument.SelectSingleNode("//" + Caml.Constants.ViewFields.Tag);
                        break;
                    }
                case "GetListItemChanges":
                    {
                        camlType = U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItemChanges;
                        containsNode = camlDocument.SelectSingleNode("//" + Caml.Constants.Contains.Tag);
                        viewFieldsNode = camlDocument.SelectSingleNode("//" + Caml.Constants.ViewFields.Tag);
                        break;
                    }
                case "GetListItemChangesSinceToken":
                    {
                        camlType = U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItemChangesSinceToken;
                        queryNode = camlDocument.SelectSingleNode("//" + Caml.Constants.Query.Tag);
                        containsNode = camlDocument.SelectSingleNode("//" + Caml.Constants.Contains.Tag);
                        viewFieldsNode = camlDocument.SelectSingleNode("//" + Caml.Constants.ViewFields.Tag);
                        queryOptionsNode = camlDocument.SelectSingleNode("//" + Caml.Constants.QueryOptions.Tag);
                        break;
                    }
                case "UpdateListItems":
                    {
                        camlType = U2U.SharePoint.CAML.Enumerations.CamlTypes.UpdateListItems;
                        batchNode = camlDocument.SelectSingleNode("//" + Caml.Constants.Batch.Tag);
                        break;
                    }
            }
        }

        #region OrderBy methods

        public XmlNode AddOrderByField(FieldObject field)
        {
            // first check if there is already a query node: both cannot exist in one query
            if (containsNode != null)
                throw new Exception("You can't add a Order By clause when you already build a Contains clause for this request.");

            XmlNode node = camlDocument.CreateElement(Caml.Constants.Query.OrderBy.FieldRef.Tag);
            if (isFieldRefName)
            {
                XmlAttribute nameAttribute = camlDocument.CreateAttribute(Caml.Constants.Query.OrderBy.FieldRef.Attributes.Name);
                nameAttribute.Value = field.InternalName;
                node.Attributes.Append(nameAttribute);
            }
            else
            {
                XmlAttribute idAttribute = camlDocument.CreateAttribute(Caml.Constants.Query.OrderBy.FieldRef.Attributes.ID);
                idAttribute.Value = field.ID.ToString();
                node.Attributes.Append(idAttribute);
            }

            OrderByNode.AppendChild(node);
            return node;
        }

        public XmlNode AddOrderByField(string internalName)
        {
            // first check if there is already a query node: both cannot exist in one query
            if (containsNode != null)
                throw new Exception("You can't add a Order By clause when you already build a Contains clause for this request.");

            if (!isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field id. Use the other overload of the AddOrderByField method instead.");

            XmlNode node = camlDocument.CreateElement(Caml.Constants.Query.OrderBy.FieldRef.Tag);
            XmlAttribute nameAttribute = camlDocument.CreateAttribute(Caml.Constants.Query.OrderBy.FieldRef.Attributes.Name);
            nameAttribute.Value = internalName;
            node.Attributes.Append(nameAttribute);

            OrderByNode.AppendChild(node);
            return node;
        }

        public XmlNode AddOrderByField(Guid fieldId)
        {
            // first check if there is already a query node: both cannot exist in one query
            if (containsNode != null)
                throw new Exception("You can't add a Order By clause when you already build a Contains clause for this request.");

            if (isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field name. Use the other overload of the AddOrderByField method instead.");

            XmlNode node = camlDocument.CreateElement(Caml.Constants.Query.OrderBy.FieldRef.Tag);
            XmlAttribute idAttribute = camlDocument.CreateAttribute(Caml.Constants.Query.OrderBy.FieldRef.Attributes.ID);
            idAttribute.Value = fieldId.ToString();
            node.Attributes.Append(idAttribute);

            OrderByNode.AppendChild(node);
            return node;
        }

        public XmlNode AddOrderByField(string internalName, bool isAscending)
        {
            XmlNode node = AddOrderByField(internalName);
            XmlAttribute ascAttribute = camlDocument.CreateAttribute(Caml.Constants.Query.OrderBy.FieldRef.Attributes.Ascending);
            ascAttribute.Value = isAscending.ToString();
            node.Attributes.Append(ascAttribute);

            return node;
        }

        public XmlNode AddOrderByField(Guid fieldId, bool isAscending)
        {
            XmlNode node = AddOrderByField(fieldId);
            XmlAttribute ascAttribute = camlDocument.CreateAttribute(Caml.Constants.Query.OrderBy.FieldRef.Attributes.Ascending);
            ascAttribute.Value = isAscending.ToString();
            node.Attributes.Append(ascAttribute);

            return node;
        }

        public XmlNode AddOrderByField(FieldObject field, bool isAscending)
        {
            XmlNode node = AddOrderByField(field);
            XmlAttribute ascAttribute = camlDocument.CreateAttribute(Caml.Constants.Query.OrderBy.FieldRef.Attributes.Ascending);
            ascAttribute.Value = isAscending.ToString();
            node.Attributes.Append(ascAttribute);

            return node;
        }

        public XmlNode AddOrderByField(FieldObject field, string sortType)
        {
            return AddOrderByField(field, (sortType == "Ascending" || sortType == "ASC"));
        }

        public XmlNode AddOrderByField(string internalName, string sortType)
        {
            return AddOrderByField(internalName, (sortType == "Ascending" || sortType == "ASC"));
        }

        public XmlNode AddOrderByField(Guid fieldId, string sortType)
        {
            return AddOrderByField(fieldId, (sortType == "Ascending" || sortType == "ASC"));
        }

        public XmlNode UpdateOrderByField(XmlNode fieldrefNode, bool isAscending)
        {
            if (fieldrefNode == null)
            {
                return null;
            }

            XmlAttribute ascAttribute = (XmlAttribute)fieldrefNode.Attributes.GetNamedItem(Caml.Constants.Query.OrderBy.FieldRef.Attributes.Ascending);
            if (ascAttribute == null && !isAscending)
            {
                ascAttribute = camlDocument.CreateAttribute(Caml.Constants.Query.OrderBy.FieldRef.Attributes.Ascending);
                ascAttribute.Value = isAscending.ToString();
                fieldrefNode.Attributes.Append(ascAttribute);
            }
            else if (ascAttribute != null)
            {
                ascAttribute.Value = isAscending.ToString();
            }
            return fieldrefNode;
        }

        public XmlNode UpdateOrderByField(XmlNode fieldrefNode, string sortType)
        {
            bool isAscending = false;
            if (sortType == "Ascending")
                isAscending = true;

            XmlNode node = UpdateOrderByField(fieldrefNode, isAscending);
            return node;
        }

        public XmlNode UpdateOrderByField(string internalName, bool isAscending)
        {
            if (!isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field id. Use the other overload of the UpdateOrderByField method instead.");

            XmlNode node = QueryNode.SelectSingleNode("//" + Caml.Constants.Query.OrderBy.Tag + "/" + Caml.Constants.Query.OrderBy.FieldRef.Tag + "[@Name='" + internalName + "']");
            if (node != null)
            {
                node = UpdateOrderByField(node, isAscending);
                return node;
            }
            return null;
        }

        public XmlNode UpdateOrderByField(Guid fieldId, bool isAscending)
        {
            if (isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field name. Use the other overload of the UpdateOrderByField method instead.");

            XmlNode node = QueryNode.SelectSingleNode("//" + Caml.Constants.Query.OrderBy.Tag + "/" + Caml.Constants.Query.OrderBy.FieldRef.Tag + "[@ID='" + fieldId.ToString() + "']");
            if (node != null)
            {
                node = UpdateOrderByField(node, isAscending);
                return node;
            }
            return null;
        }

        public XmlNode UpdateOrderByField(string internalName, string sortType)
        {
            bool isAscending = false;
            if (sortType == "Ascending")
                isAscending = true;

            XmlNode node = UpdateOrderByField(internalName, isAscending);
            return node;
        }

        public XmlNode UpdateOrderByField(Guid fieldId, string sortType)
        {
            bool isAscending = false;
            if (sortType == "Ascending")
                isAscending = true;

            XmlNode node = UpdateOrderByField(fieldId, isAscending);
            return node;
        }

        public void RemoveOrderByField(string internalName)
        {
            if (!isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field id. Use the other overload of the RemoveOrderByField method instead.");

            XmlNode node = QueryNode.SelectSingleNode("//" + Caml.Constants.Query.OrderBy.Tag + "/" + Caml.Constants.Query.OrderBy.FieldRef.Tag + "[@Name='" + internalName + "']");
            if (node != null)
            {
                if (node.ParentNode.ChildNodes.Count == 1)
                {
                    QueryNode.RemoveChild(OrderByNode);
                    orderByNode = null;
                }
                else
                    OrderByNode.RemoveChild(node);
            }
        }

        public void RemoveOrderByField(Guid fieldId)
        {
            if (isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field name. Use the other overload of the RemoveOrderByField method instead.");

            XmlNode node = QueryNode.SelectSingleNode("//" + Caml.Constants.Query.OrderBy.Tag + "/" + Caml.Constants.Query.OrderBy.FieldRef.Tag + "[@ID='" + fieldId.ToString() + "']");
            if (node != null)
            {
                if (node.ParentNode.ChildNodes.Count == 1)
                {
                    QueryNode.RemoveChild(OrderByNode);
                    orderByNode = null;
                }
                else
                    OrderByNode.RemoveChild(node);
            }
        }

        public void RemoveOrderByField(XmlNode fieldNode)
        {
            if (fieldNode != null)
            {
                if (fieldNode.ParentNode.ChildNodes.Count == 1)
                    this.RemoveOrderByNode();
                else
                    OrderByNode.RemoveChild(fieldNode);
            }
        }

        #endregion

        #region Where methods

        public XmlNode AddWhereField(string internalName, string valueString, string dataType, string operatorTag, string combinerTag, out bool addCombinerNode)
        {
            addCombinerNode = false;

            if (operatorTag != "IsNull" && operatorTag != "IsNotNull")
            {
                // it is required that there is a value in the value text box
                if (string.IsNullOrEmpty(valueString))
                {
                    return null;
                }
            }

            XmlNode combinerNode = AddCombinerNode(combinerTag, out addCombinerNode);

            // create the where node
            XmlNode node = CreateWhereFieldNode(operatorTag, internalName, dataType, valueString);

            // append the new field node to the combiner node or the where node
            if (combinerNode == null)
            {
                WhereNode.AppendChild(node);
            }
            else
            {
                combinerNode.AppendChild(node);
            }

            return node;
        }


        public XmlNode AddWhereField(Guid fieldId, string valueString, string dataType, string operatorTag, string combinerTag, out bool addCombinerNode)
        {
            if (isFieldRefName)
            {
                throw new Exception("You cannot use this method when you want to query by field name. Use the other overload of the AddWhereField method instead.");
            }

            return AddWhereField(fieldId.ToString(), valueString, dataType, operatorTag, combinerTag, out addCombinerNode);
        }

        public XmlNode AddWhereField(string internalName, string valueString, string dataType, string operatorTag, out bool addCombinerNode)
        {
            if (!isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field id. Use the other overload of the AddWhereField method instead.");

            return AddWhereField(internalName, valueString, dataType, operatorTag, "And", out addCombinerNode);
        }

        public XmlNode AddWhereField(Guid fieldId, string valueString, string dataType, string operatorTag, out bool addCombinerNode)
        {
            if (isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field name. Use the other overload of the AddWhereField method instead.");

            return AddWhereField(fieldId.ToString(), valueString, dataType, operatorTag, "And", out addCombinerNode);
        }

        public XmlNode AddWhereField(string internalName, DateTime dateValue, string dataType, string operatorTag, string combinerTag, out bool addCombinerNode)
        {
            if (!isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field id. Use the other overload of the AddWhereField method instead.");

            string valueString = U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(dateValue);
            return AddWhereField(internalName, valueString, dataType, operatorTag, combinerTag, out addCombinerNode);
        }

        public XmlNode AddWhereField(Guid fieldId, DateTime dateValue, string dataType, string operatorTag, string combinerTag, out bool addCombinerNode)
        {
            if (isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field name. Use the other overload of the AddWhereField method instead.");

            string valueString = U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(dateValue);
            return AddWhereField(fieldId.ToString(), valueString, dataType, operatorTag, combinerTag, out addCombinerNode);
        }

        public XmlNode AddWhereField(string DateRangesOverlap, U2U.SharePoint.CAML.Enumerations.OccurrenceTypes occurrenceType, string combinerTag, out bool addCombinerNode)
        {
            //<DateRangesOverlap><FieldRef Name=\"EventDate\" /><FieldRef Name=\"EndDate\" /><FieldRef Name=\"RecurrenceID\" />
            // <Value Type=\"DateTime\"><Month /></Value></DateRangesOverlap>

            // first check if there is already a query node: both cannot exist in one query
            if (containsNode != null)
                throw new Exception("You can't add a Where clause when you already build a Contains clause for this request.");

            XmlNode combinerNode = null;
            addCombinerNode = false;

            if (viewFieldsNode != null)
                AddViewField("fRecurrence");

            // first check if the DateRangesOverlap node does not already exist
            XmlNode operatorNode = WhereNode.SelectSingleNode("//" + Caml.Constants.Query.Where.DateRangesOverlap);
            if (operatorNode == null)
            {
                combinerNode = AddCombinerNode(combinerTag, out addCombinerNode);

                // create the DateRangesOverlap node
                operatorNode = camlDocument.CreateElement(Caml.Constants.Query.Where.DateRangesOverlap);

                // add the FieldRef nodes
                XmlNode eventDateNode = AddFieldRefNode(U2U.SharePoint.CAML.Enumerations.CalendarFields.EventDate.ToString());
                operatorNode.AppendChild(eventDateNode);
                XmlNode endDateNode = AddFieldRefNode(U2U.SharePoint.CAML.Enumerations.CalendarFields.EndDate.ToString());
                operatorNode.AppendChild(endDateNode);
                XmlNode recurrenceIDNode = AddFieldRefNode(U2U.SharePoint.CAML.Enumerations.CalendarFields.RecurrenceID.ToString());
                operatorNode.AppendChild(recurrenceIDNode);

                // add the Value node 
                XmlNode valueNode = camlDocument.CreateElement(Caml.Constants.Query.Where.ValueType.Tag);
                valueNode.InnerXml = "<" + occurrenceType.ToString() + "/>";
                XmlAttribute valueatt = camlDocument.CreateAttribute(Caml.Constants.Query.Where.ValueType.Attributes.Type);
                valueatt.Value = U2U.SharePoint.CAML.Enumerations.DataTypes.DateTime.ToString();
                valueNode.Attributes.Append(valueatt);
                operatorNode.AppendChild(valueNode);

                // append the new field node to the combiner node or the where node
                if (combinerNode == null)
                    WhereNode.AppendChild(operatorNode);
                else
                    combinerNode.AppendChild(operatorNode);

            }
            else
            {
                XmlNode valueNode = operatorNode.SelectSingleNode("//" + Caml.Constants.Query.Where.DateRangesOverlap + "/" + Caml.Constants.Query.Where.ValueType.Tag);
                if (valueNode != null)
                {
                    valueNode.InnerXml = "<" + occurrenceType.ToString() + "/>";
                }
            }

            return operatorNode;



        }

        public XmlNode UpdateWhereField(XmlNode fieldNode, string valueString)
        {
            // check if it is the correct Node that has been passed i.e. <Eq><FieldRef>.....</Eq>
            if (fieldNode.FirstChild.Name != Caml.Constants.Query.Where.FieldRef.Tag)
                throw new ApplicationException("You passed an invalid node. The node should be of the format <Eq><FieldRef>.....</Eq>.");

            XmlNode valueNode = fieldNode.SelectSingleNode(Caml.Constants.Query.Where.ValueType.Tag);
            if (valueNode != null)
                valueNode.InnerText = valueString;
            return fieldNode;
        }
        public XmlNode UpdateWhereField(XmlNode fieldNode, string valueString, string dataType, string operatorTag)
        {
            // check if it is the correct Node that has been passed i.e. <Eq><FieldRef>.....</Eq>
            if (fieldNode.FirstChild.Name != Caml.Constants.Query.Where.FieldRef.Tag)
                throw new ApplicationException("You passed an invalid node. The node should be of the format <Eq><FieldRef>.....</Eq>.");

            if (operatorTag != "IsNull" && operatorTag != "IsNotNull")
            {
                // it is required that there is a value
                if (valueString == string.Empty)
                    throw new ApplicationException("Please, fill out a value for the selected field");
            }

            // check if the incoming node is of the correct format
            string internalName = null;
            XmlAttribute nameAttribute = null;
            if (isFieldRefName)
                nameAttribute = (XmlAttribute)fieldNode.FirstChild.Attributes.GetNamedItem(Caml.Constants.Query.Where.FieldRef.Attributes.Name);
            else
                nameAttribute = (XmlAttribute)fieldNode.FirstChild.Attributes.GetNamedItem(Caml.Constants.Query.Where.FieldRef.Attributes.ID);

            if (nameAttribute != null)
                internalName = nameAttribute.Value;
            else
                throw new ApplicationException("You passed an invalid FieldRef node within the incoming node");

            // change the operator of the node
            if (fieldNode.Name != operatorTag)
            {
                // first remove the FieldRef node with corresponding parent from the CAML string
                this.RemoveWhereField(fieldNode);
                // than add it again with the new operator			
                bool addCombinerNode;
                return this.AddWhereField(internalName, valueString, dataType, operatorTag, out addCombinerNode);
            }
            else
            {
                // change the data type of the node
                if (dataType == null)
                    dataType = "Text";

                if (fieldNode.FirstChild.NextSibling != null)
                {
                    // it is possible that no Value node was added in case of a IsNull or IsNotNull tag
                    XmlAttribute typeAttribute = (XmlAttribute)fieldNode.FirstChild.NextSibling.Attributes.GetNamedItem(Caml.Constants.Query.Where.ValueType.Attributes.Type);
                    if (typeAttribute != null && dataType != typeAttribute.Value)
                        typeAttribute.Value = dataType;
                    if (operatorTag == "IsNull" || operatorTag == "IsNotNull")
                        fieldNode.RemoveChild(fieldNode.FirstChild.NextSibling);
                    // change the value of the node
                    XmlNode valueNode = fieldNode.SelectSingleNode(Caml.Constants.Query.Where.ValueType.Tag);
                    if (dataType == "DateTime" && valueString.Substring(0, 1) != "[")
                    {
                        // check if the value string has a DateTime format or an ISO8601 (CAML format)
                        DateTime dt;
                        if (DateTime.TryParse(valueString, out dt))
                            valueString = U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(dt);
                    }
                    if (valueNode != null && valueNode.InnerText != valueString)
                        valueNode.InnerText = valueString;
                }
                else if (operatorTag != "IsNull" && operatorTag != "IsNotNull")
                {
                    // add the Value node
                    XmlNode valueNode = camlDocument.CreateElement(Caml.Constants.Query.Where.ValueType.Tag);
                    valueNode.InnerText = valueString;
                    XmlAttribute valueatt = camlDocument.CreateAttribute(Caml.Constants.Query.Where.ValueType.Attributes.Type);
                    valueatt.Value = dataType;
                    if (dataType == "DateTime" && valueString.Substring(0, 1) != "[")
                    {
                        // check if the value string has a DateTime format or an ISO8601 (CAML format)
                        DateTime dt;
                        if (DateTime.TryParse(valueString, out dt))
                            valueString = U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(dt);
                    }
                    valueNode.Attributes.Append(valueatt);
                    valueNode.InnerText = valueString;
                    fieldNode.AppendChild(valueNode);
                }
            }
            return fieldNode;
        }

        public XmlNode UpdateWhereField(XmlNode fieldNode, DateTime dateValue)
        {
            string valueString = U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(dateValue);

            return UpdateWhereField(fieldNode, valueString);
        }

        public XmlNode UpdateWhereField(XmlNode fieldNode, DateTime dateValue, string operatorTag)
        {
            string valueString = U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(dateValue);

            return UpdateWhereField(fieldNode, valueString, null, operatorTag);
        }

        public XmlNode UpdateWhereField(Guid fieldId, string operatorTag, string oldValueString, string newValueString)
        {
            if (isFieldRefName)
            {
                throw new Exception("You cannot use this method when you want to query by field name. Use the other overload of the UpdateWhereField method instead.");
            }

            return UpdateWhereField(fieldId.ToString(), operatorTag, oldValueString, newValueString);
        }

        public XmlNode UpdateWhereField(string internalName, string operatorTag, string oldValueString, string newValueString)
        {
            string xpath = null;
            if (isFieldRefName)
            {
                xpath = "//" + Caml.Constants.Query.Where.Tag + "/*/" + Caml.Constants.Query.Where.FieldRef.Tag +
                    "[@" + Caml.Constants.Query.Where.FieldRef.Attributes.Name + "='" + internalName + "']";
            }
            else
            {
                xpath = "//" + Caml.Constants.Query.Where.Tag + "/*/" + Caml.Constants.Query.Where.FieldRef.Tag +
                    "[@" + Caml.Constants.Query.Where.FieldRef.Attributes.ID + "='" + internalName + "']";
            }
            XmlNodeList nodeList = QueryNode.SelectNodes(xpath);

            if (nodeList == null || nodeList.Count == 0)
            {
                // TODO: dit geeft problemen wanneer eenzelfde node 2x gebruikt wordt in de WHERE clause
                // this means that it is possible that there is a combiner node, so reexecute with a different xpath
                if (isFieldRefName)
                {
                    xpath = "//" + Caml.Constants.Query.Where.Tag + "/*/" + operatorTag + "/" + Caml.Constants.Query.Where.FieldRef.Tag +
                    "[@" + Caml.Constants.Query.Where.FieldRef.Attributes.Name + "='" + internalName + "']";
                }
                else
                {
                    xpath = "//" + Caml.Constants.Query.Where.Tag + "/*/" + operatorTag + "/" + Caml.Constants.Query.Where.FieldRef.Tag +
                    "[@" + Caml.Constants.Query.Where.FieldRef.Attributes.ID + "='" + internalName + "']";
                }
                nodeList = QueryNode.SelectNodes(xpath);
            }

            // TODO: dit geeft wel een probleem als hetzelfde veld 2x met dezelfde waarde werd toegevoegd
            if (nodeList.Count == 1)
            {
                // the parent node is the Where or And or Or node
                XmlNode parentNode = nodeList[0].ParentNode.ParentNode;

                // gather the details of the current node
                string dataType = null;
                XmlAttribute typeAttribute = (XmlAttribute)nodeList[0].FirstChild.NextSibling.Attributes.GetNamedItem(Caml.Constants.Query.Where.ValueType.Attributes.Type);
                if (typeAttribute != null)
                    dataType = typeAttribute.Value;
                string combinerTag = null;
                if (parentNode.Name != Caml.Constants.Query.Where.Tag)
                    combinerTag = parentNode.Name;

                // remove the FieldRef node with corresponding parent from the CAML string
                parentNode.RemoveChild(nodeList[0].ParentNode);

                // insert the FieldRef node with corresponding parent again
                bool addCombinerNode;
                return AddWhereField(internalName, newValueString, dataType, operatorTag, combinerTag, out addCombinerNode);
            }
            else if (nodeList.Count > 1)
            {
                throw new ApplicationException("Cannot execute the update because more than 1 node with the same FieldRef exists in the WHERE clause.");
            }
            return null;
        }

        public XmlNode UpdateWhereField(string internalName, string operatorTag, DateTime oldDateValue, DateTime newDateValue)
        {
            string oldValueString = U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(oldDateValue);
            string newValueString = U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(newDateValue);
            return UpdateWhereField(internalName, operatorTag, oldValueString, newValueString);
        }

        public XmlNode UpdateWhereField(Guid fieldId, string operatorTag, DateTime oldDateValue, DateTime newDateValue)
        {
            if (isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field name. Use the other overload of the UpdateWhereField method instead.");

            return UpdateWhereField(fieldId.ToString(), operatorTag, oldDateValue, newDateValue);
        }

        public void RemoveWhereField(XmlNode fieldNode)
        {
            if (fieldNode == null) return;

            if (fieldNode.ParentNode.Name == Caml.Constants.Query.Where.Tag && fieldNode.ParentNode.ChildNodes.Count == 1)
                this.RemoveWhereNode();
            else if (fieldNode.ParentNode.Name == "And" || fieldNode.ParentNode.Name == "Or")
            {
                XmlNode combinerNode = fieldNode.ParentNode;
                combinerNode.RemoveChild(fieldNode);
                if (combinerNode.ChildNodes.Count == 1)
                {
                    // check if other fields are there
                    XmlNode nextChild = combinerNode.ChildNodes[0];
                    combinerNode.RemoveChild(nextChild);
                    combinerNode.ParentNode.AppendChild(nextChild);
                    combinerNode.ParentNode.RemoveChild(combinerNode);
                }
                else if (combinerNode.ChildNodes.Count == 0)
                    WhereNode.RemoveChild(combinerNode);
            }
            else
                WhereNode.RemoveChild(fieldNode);
        }

        public void RemoveWhereField(string internalName, string valueString, string operatorTag)
        {
            throw new NotImplementedException();
            // TODO : dit gaat problemen geven wanneer een veld 2x in de Where clause voorkomt
            //			string xpath = null;
            //			if (combiner == null)
            //				xpath = "//" + Caml.Constants.Query.Where.Tag + "/*/" + Caml.Constants.Query.Where.FieldRef.Tag + "[@Name='" + whereField.FieldRef + "']";
            //			else
            //				xpath = "//" + Caml.Constants.Query.Where.Tag + "/" + combiner + "/*/" + Caml.Constants.Query.Where.FieldRef.Tag + "[@Name='" + whereField.FieldRef + "']";
            //				
            //			XmlNode node = whereNode.SelectSingleNode(xpath);
            //			if (node == null) return;
        }

        public void RemoveWhereField(Guid fieldId, string valueString, string operatorTag)
        {
            throw new NotImplementedException();
        }

        public void RemoveWhereField(string internalName, DateTime dateValue, string operatorTag)
        {
            throw new NotImplementedException();
        }

        public void RemoveWhereField(Guid fieldId, DateTime dateValue, string operatorTag)
        {
            throw new NotImplementedException();
        }


        private XmlNode CreateWhereFieldNode(string operatorTag, string internalName, string dataType, string valueString)
        {
            // first check if there is already a query node: both cannot exist in one query
            if (containsNode != null)
            {
                throw new Exception("You can't add a Where clause when you already build a Contains clause for this request.");
            }

            XmlNode operatorNode = camlDocument.CreateElement(operatorTag);

            // add the FieldRef node
            XmlNode fieldrefNode = AddFieldRefNode(internalName);
            operatorNode.AppendChild(fieldrefNode);

            // add the Value node
            if (operatorTag != "IsNull" && operatorTag != "IsNotNull")
            {
                XmlNode valueNode = camlDocument.CreateElement(Caml.Constants.Query.Where.ValueType.Tag);
                valueNode.InnerText = valueString;
                XmlAttribute valueatt = camlDocument.CreateAttribute(Caml.Constants.Query.Where.ValueType.Attributes.Type);
                valueatt.Value = dataType;
                if (dataType == "DateTime" && valueString.Substring(0, 1) != "["
                    && (valueString.Length > 4 && valueString.Substring(0, 4) != "<Now")
                    && (valueString.Length > 6 && valueString.Substring(0, 6) != "<Today"))
                {
                    // check if the value string has a DateTime format or an ISO8601 (CAML format)
                    DateTime dt;
                    if (DateTime.TryParse(valueString, out dt))
                    {
                        valueString = U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(dt);
                    }
                    // 2005-5-27T00:00:00Z
                    if (valueString.Length > 18 && string.Compare(valueString.Substring(11, 8), "00:00:00", true) > 0)
                    {
                        XmlAttribute timeatt = camlDocument.CreateAttribute(Caml.Constants.Query.Where.ValueType.Attributes.IncludeTimeValue);
                        timeatt.Value = "TRUE";
                        valueNode.Attributes.Append(timeatt);
                    }
                }
                else if (dataType == "DateTime" && valueString.Length > 4 && valueString.Substring(0, 4) == "<Now")
                {
                    // <Value Type=”DateTime” IncludeTimeValue=”TRUE">
                    valueString = U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(DateTime.Now);
                    XmlAttribute timeatt = camlDocument.CreateAttribute(Caml.Constants.Query.Where.ValueType.Attributes.IncludeTimeValue);
                    timeatt.Value = "TRUE";
                    valueNode.Attributes.Append(timeatt);
                }

                valueNode.Attributes.Append(valueatt);
                if (valueString.Length > 2 && valueString[0].Equals('<') && valueString[valueString.Length - 1].Equals('>'))
                {
                    valueNode.InnerXml = valueString;
                }
                else
                {
                    valueNode.InnerText = valueString;
                }
                operatorNode.AppendChild(valueNode);
            }

            return operatorNode;
        }

        public XmlNode AddAndOrNode(string andOrTag, XmlNode combinerNode)
        {
            if (string.IsNullOrEmpty(andOrTag))
            {
                andOrTag = "And";
            }

            XmlNode andOrNode = camlDocument.CreateElement(andOrTag);
            if (combinerNode != null)
            {
                combinerNode.AppendChild(andOrNode);
            }

            return andOrNode;
        }

        public XmlNode AddCombinerNode(string combinerTag, out bool addCombinerNode)
        {
            addCombinerNode = false;
            XmlNode combinerNode = null;

            if (string.IsNullOrEmpty(combinerTag))
            {
                combinerTag = "And";
            }

            // check if there is already a field node or combiner node
            if (WhereNode.HasChildNodes)
            {
                if (WhereNode.FirstChild.FirstChild.Name == Caml.Constants.Query.Where.FieldRef.Tag)
                {
                    // add a combiner node in between
                    addCombinerNode = true;
                    combinerNode = camlDocument.CreateElement(combinerTag);
                    XmlNode childNode = WhereNode.FirstChild;
                    WhereNode.AppendChild(combinerNode);
                    combinerNode.AppendChild(childNode);
                }
                else
                {
                    // get the corresponding combiner node
                    foreach (XmlNode childNode in WhereNode.ChildNodes)
                    {
                        if (childNode.Name == combinerTag)
                        {
                            // check how many children this node has
                            if (childNode.ChildNodes.Count == 2)
                            {
                                // an extra combiner node should be added
                                combinerNode = camlDocument.CreateElement(combinerTag);
                                WhereNode.AppendChild(combinerNode);
                                WhereNode.RemoveChild(childNode);
                                combinerNode.AppendChild(childNode);
                                break;
                            }
                            else
                            {
                                combinerNode = childNode;
                                break;
                            }
                        }
                    }
                    if (combinerNode == null)
                    {
                        addCombinerNode = true;
                        combinerNode = camlDocument.CreateElement(combinerTag);
                        WhereNode.AppendChild(combinerNode);
                    }
                }
            }
            return combinerNode;
        }

        private XmlNode AddFieldRefNode(string internalName)
        {
            XmlNode fieldrefNode = camlDocument.CreateElement(Caml.Constants.Query.Where.FieldRef.Tag);
            XmlAttribute nameAttribute = null;

            if (isFieldRefName)
            {
                nameAttribute = camlDocument.CreateAttribute(Caml.Constants.Query.OrderBy.FieldRef.Attributes.Name);
            }
            else
            {
                nameAttribute = camlDocument.CreateAttribute(Caml.Constants.Query.OrderBy.FieldRef.Attributes.ID);
            }

            nameAttribute.Value = internalName;
            fieldrefNode.Attributes.Append(nameAttribute);

            return fieldrefNode;
        }

        #endregion

        #region GetListItems methods
        public XmlNode AddViewField(string internalName)
        {
            XmlNode node = camlDocument.SelectSingleNode("//" + Caml.Constants.ViewFields.Tag + "/"
                + Caml.Constants.ViewFields.FieldRef.Tag + "[@Name='" + internalName + "']");
            if (node == null)
            {
                node = camlDocument.CreateElement(Caml.Constants.ViewFields.FieldRef.Tag);
                XmlAttribute nameAttribute = camlDocument.CreateAttribute(Caml.Constants.ViewFields.FieldRef.Attributes.Name);
                nameAttribute.Value = internalName;
                node.Attributes.Append(nameAttribute);
                ViewFieldsNode.AppendChild(node);
            }
            return node;
        }

        //public XmlNode AddViewField(Guid fieldId)
        //{
        //    if (isFieldRefName)
        //        throw new Exception("You cannot use this method when you want to query by field name. Use the other overload of the AddViewField method instead.");

        //    XmlNode node = camlDocument.SelectSingleNode("//" + Caml.Constants.ViewFields.Tag + "/"
        //        + Caml.Constants.ViewFields.FieldRef.Tag + "[.='" + fieldId.ToString() + "']");
        //    if (node == null)
        //    {
        //        node = camlDocument.CreateElement(Caml.Constants.ViewFields.FieldRef.Tag);
        //        XmlAttribute idAttribute = camlDocument.CreateAttribute(Caml.Constants.ViewFields.FieldRef.Attributes.ID);
        //        idAttribute.Value = fieldId.ToString();
        //        node.Attributes.Append(idAttribute);
        //        ViewFieldsNode.AppendChild(node);
        //    }
        //    return node;
        //}

        public void RemoveViewField(string internalName)
        {
            if (!isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field id. Use the other overload of the AddViewField method instead.");

            string xpath = "//" + Caml.Constants.ViewFields.Tag + "/" + Caml.Constants.ViewFields.FieldRef.Tag
                + "[@" + Caml.Constants.ViewFields.FieldRef.Attributes.Name + "='" + internalName + "']";
            XmlNode node = camlDocument.SelectSingleNode(xpath);
            if (node != null && node.ParentNode != null)
                node.ParentNode.RemoveChild(node);
        }

        public void RemoveViewField(Guid fieldId)
        {
            if (!isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field name. Use the other overload of the AddViewField method instead.");

            string xpath = "//" + Caml.Constants.ViewFields.Tag + "/" + Caml.Constants.ViewFields.FieldRef.Tag
                + "[@" + Caml.Constants.ViewFields.FieldRef.Attributes.ID + "='" + fieldId.ToString() + "']";
            XmlNode node = camlDocument.SelectSingleNode(xpath);
            if (node != null && node.ParentNode != null)
                node.ParentNode.RemoveChild(node);
        }

        public void RemoveViewField(XmlNode viewFieldNode)
        {
            if (viewFieldNode != null && viewFieldNode.ParentNode != null)
                viewFieldNode.ParentNode.RemoveChild(viewFieldNode);
        }

        public XmlNode AddQueryOptionField(string queryOption, string value)
        {
            XmlNode node = camlDocument.SelectSingleNode("//" + Caml.Constants.QueryOptions.Tag + "/"
                + queryOption);
            if (node == null)
            {
                node = camlDocument.CreateElement(queryOption);
                QueryOptionsNode.AppendChild(node);
            }
            switch (queryOption)
            {
                case "ViewAttributes":
                    XmlAttribute attribute = camlDocument.CreateAttribute(Caml.Constants.QueryOptions.Scope);
                    attribute.Value = "Recursive";
                    node.Attributes.Append(attribute);
                    break;

                case "ExtraIds":
                    if (node.InnerText.Length > 0)
                        node.InnerText += ",";
                    node.InnerText += value;
                    break;

                default:
                    node.InnerText = value;
                    break;
            }
            return node;
        }

        public XmlNode AddQueryOptionField(string queryOption, bool value)
        {
            return AddQueryOptionField(queryOption, value.ToString());
        }

        public XmlNode AddQueryOptionField(string queryOption, DateTime value)
        {
            string stringvalue = U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(value);

            return AddQueryOptionField(queryOption, stringvalue);
        }

        public void RemoveQueryOptionField(string queryOption)
        {
            XmlNode node = camlDocument.SelectSingleNode("//" + Caml.Constants.QueryOptions.Tag + "/"
                + queryOption);
            if (node != null && node.ParentNode != null)
                node.ParentNode.RemoveChild(node);
        }

        public void RemoveQueryOptionField(XmlNode queryOptionNode)
        {
            if (queryOptionNode != null && queryOptionNode.ParentNode != null)
                queryOptionNode.ParentNode.RemoveChild(queryOptionNode);
        }
        #endregion

        #region UpdateListItems methods
        public void UpdateBatchNode(string batchAttribute, string value)
        {
            if (batchAttribute != Caml.Constants.Batch.OnError &&
                batchAttribute != Caml.Constants.Batch.PreCalc &&
                batchAttribute != Caml.Constants.Batch.RootFolder &&
                batchAttribute != Caml.Constants.Batch.ListVersion &&
                batchAttribute != Caml.Constants.Batch.ViewName)
                throw new ApplicationException(batchAttribute + " is an invalid attribute for the Batch node of UpdateListItems");

            XmlAttribute att = (XmlAttribute)BatchNode.Attributes.GetNamedItem(batchAttribute);
            if (att == null)
            {
                att = camlDocument.CreateAttribute(batchAttribute);
                BatchNode.Attributes.Append(att);
            }
            att.Value = value;
        }

        public void RemoveBatchNode(string batchAttribute)
        {
            if (batchAttribute != Caml.Constants.Batch.OnError &&
                batchAttribute != Caml.Constants.Batch.PreCalc &&
                batchAttribute != Caml.Constants.Batch.RootFolder &&
                batchAttribute != Caml.Constants.Batch.ListVersion &&
                batchAttribute != Caml.Constants.Batch.ViewName)
                throw new ApplicationException(batchAttribute + " is an invalid attribute for the Batch node of UpdateListItems");

            XmlAttribute att = (XmlAttribute)BatchNode.Attributes.GetNamedItem(batchAttribute);
            if (att != null)
            {
                BatchNode.Attributes.Remove(att);
            }
        }

        public void AddMethodNode(int methodID, string methodCommand)
        {
            if (methodCommand != Caml.Constants.Batch.Method.Command.New &&
                methodCommand != Caml.Constants.Batch.Method.Command.Update &&
                methodCommand != Caml.Constants.Batch.Method.Command.Delete)
                throw new ApplicationException(methodCommand + " is an invalid attribute for the Method node of UpdateListItems");

            XmlNode node = camlDocument.CreateElement(Caml.Constants.Batch.Method.Tag);
            BatchNode.AppendChild(node);

            XmlAttribute att = camlDocument.CreateAttribute(Caml.Constants.Batch.Method.ID);
            att.Value = methodID.ToString();
            node.Attributes.Append(att);

            att = camlDocument.CreateAttribute(Caml.Constants.Batch.Method.Command.Tag);
            att.Value = methodCommand;
            node.Attributes.Append(att);
        }

        public void UpdateMethodNode(int methodID, string methodCommand)
        {
            if (methodCommand != Caml.Constants.Batch.Method.Command.New &&
                methodCommand != Caml.Constants.Batch.Method.Command.Update &&
                methodCommand != Caml.Constants.Batch.Method.Command.Delete)
                throw new ApplicationException(methodCommand + " is an invalid attribute for the Method node of UpdateListItems");

            XmlNode node = BatchNode.SelectSingleNode("//" + Caml.Constants.Batch.Method.Tag + "[@" + Caml.Constants.Batch.Method.ID + " = " + methodID + "]");
            if (node != null)
            {
                XmlAttribute att = (XmlAttribute)node.Attributes.GetNamedItem(Caml.Constants.Batch.Method.Command.Tag);
                if (att != null)
                    att.Value = methodCommand;
            }
        }

        public void RemoveMethodNode(int methodID)
        {
            XmlNode methodNode = BatchNode.SelectSingleNode("//" + Caml.Constants.Batch.Method.Tag + "[@" + Caml.Constants.Batch.Method.ID + " = " + methodID + "]");
            if (methodNode != null)
                BatchNode.RemoveChild(methodNode);
        }

        public void AddFieldNode(int methodID, string fieldName, string fieldValue)
        {
            XmlNode methodNode = BatchNode.SelectSingleNode("//" + Caml.Constants.Batch.Method.Tag + "[@" + Caml.Constants.Batch.Method.ID + " = " + methodID + "]");
            if (methodNode != null)
            {
                // check if the field node doesn't already exist
                XmlNode fieldNode = methodNode.SelectSingleNode(Caml.Constants.Batch.Method.Field.Tag + "[@" + Caml.Constants.Batch.Method.Field.Name + " = '" + fieldName + "']");
                if (fieldNode != null)
                    fieldNode.InnerText = fieldValue;
                else
                {
                    fieldNode = camlDocument.CreateElement(Caml.Constants.Batch.Method.Field.Tag);
                    XmlAttribute att = camlDocument.CreateAttribute(Caml.Constants.Batch.Method.Field.Name);
                    att.Value = fieldName;
                    fieldNode.Attributes.Append(att);
                    fieldNode.InnerText = fieldValue;
                    methodNode.AppendChild(fieldNode);

                    //					// for testing reasons
                    //					fieldNode = camlDocument.CreateElement(Caml.Constants.Batch.Method.Field.Tag);
                    //					XmlAttribute att2 = camlDocument.CreateAttribute(Caml.Constants.Batch.Method.Field.Name);
                    //					att2.Value = "FileRef";
                    //					fieldNode.Attributes.Append(att2);
                    //					methodNode.AppendChild(fieldNode);

                }
            }
        }

        public void UpdateFieldNode(int methodID, string fieldName, string fieldValue)
        {
            XmlNode methodNode = BatchNode.SelectSingleNode("//" + Caml.Constants.Batch.Method.Tag + "[@" + Caml.Constants.Batch.Method.ID + " = " + methodID + "]");
            if (methodNode != null)
            {
                XmlNode fieldNode = methodNode.SelectSingleNode(Caml.Constants.Batch.Method.Field.Tag + "[@" + Caml.Constants.Batch.Method.Field.Name + " = '" + fieldName + "']");
                if (fieldNode != null)
                    fieldNode.InnerText = fieldValue;
            }
        }

        public void RemoveFieldNode(int methodID, string fieldName)
        {
            XmlNode methodNode = BatchNode.SelectSingleNode("//" + Caml.Constants.Batch.Method.Tag + "[@" + Caml.Constants.Batch.Method.ID + " = " + methodID + "]");
            if (methodNode != null)
            {
                XmlNode fieldNode = methodNode.SelectSingleNode(Caml.Constants.Batch.Method.Field.Tag + "[@" + Caml.Constants.Batch.Method.Field.Name + " = '" + fieldName + "']");
                if (fieldNode != null)
                    methodNode.RemoveChild(fieldNode);
            }
        }
        #endregion

        #region GetListItemChanges
        public XmlNode AddContainsField(Guid fieldId, string valueString, string dataType)
        {
            // first check if there is already a query node: both cannot exist in one query
            if (queryNode != null)
                throw new Exception("You can't add a Contains clause when you already build a Query for this request.");

            if (isFieldRefName)
                throw new Exception("You cannot use this method when you want to query by field name. Use the other AddContainsField method instead.");

            XmlNode node = ContainsNode.SelectSingleNode("//" + Caml.Constants.Contains.Tag + "/"
                + Caml.Constants.ViewFields.FieldRef.Tag + "[.='" + fieldId.ToString() + "']");
            if (node == null)
            {
                node = camlDocument.CreateElement(Caml.Constants.Contains.FieldRef.Tag);
                XmlAttribute idAttribute = camlDocument.CreateAttribute(Caml.Constants.Contains.FieldRef.Attributes.ID);
                idAttribute.Value = fieldId.ToString();
                node.Attributes.Append(idAttribute);
                ContainsNode.AppendChild(node);

                // add the Value node
                XmlNode valueNode = camlDocument.CreateElement(Caml.Constants.Contains.ValueType.Tag);
                valueNode.InnerText = valueString;
                XmlAttribute valueatt = camlDocument.CreateAttribute(Caml.Constants.Contains.ValueType.Attributes.Type);
                valueatt.Value = dataType;
                valueNode.Attributes.Append(valueatt);
                valueNode.InnerText = valueString;
                ContainsNode.AppendChild(valueNode);
            }
            return node;
        }

        public XmlNode AddContainsField(string internalName, string valueString, string dataType)
        {
            //<Contains>
            //   <FieldRef Name="Status"/>
            //   <Value Type="Text">Complete</Value>
            //</Contains>

            // first check if there is already a query node: both cannot exist in one query
            if (queryNode != null)
            {
                throw new Exception("You can't add a Contains clause when you already build a Query for this request.");
            }

            if (!isFieldRefName)
            {
                throw new Exception("You cannot use this method when you want to query by field id. Use the other AddContainsField method instead.");
            }

            XmlNode node = ContainsNode.SelectSingleNode("//" + Caml.Constants.Contains.Tag + "/"
                + Caml.Constants.ViewFields.FieldRef.Tag + "[.='" + internalName + "']");
            if (node == null)
            {
                node = camlDocument.CreateElement(Caml.Constants.Contains.FieldRef.Tag);
                XmlAttribute nameAttribute = camlDocument.CreateAttribute(Caml.Constants.Contains.FieldRef.Attributes.Name);
                nameAttribute.Value = internalName;
                node.Attributes.Append(nameAttribute);
                ContainsNode.AppendChild(node);

                // add the Value node
                XmlNode valueNode = camlDocument.CreateElement(Caml.Constants.Contains.ValueType.Tag);
                valueNode.InnerText = valueString;
                XmlAttribute valueatt = camlDocument.CreateAttribute(Caml.Constants.Contains.ValueType.Attributes.Type);
                valueatt.Value = dataType;
                valueNode.Attributes.Append(valueatt);
                valueNode.InnerText = valueString;
                ContainsNode.AppendChild(valueNode);
            }

            return node;
        }
        #endregion

        #region Parameter methods

        public List<CamlParameter> GetEmptyParameterStructure()
        {
            List<CamlParameter> parameterList = new List<CamlParameter>();

            switch (camlType)
            {
                case CamlTypes.Query:
                    {
                        if (whereNode == null)
                        {
                            return null;
                        }

                        GetParametersInNode(whereNode, Caml.Constants.Query.Where.ValueType.Tag, parameterList);
                        break;
                    }
                case CamlTypes.GetListItems:
                case CamlTypes.GetListItemChanges:
                case CamlTypes.GetListItemChangesSinceToken:
                    {
                        if (queryNode == null && containsNode == null)
                        {
                            return null;
                        }
                        GetParametersInNode(queryNode, Caml.Constants.Query.Where.ValueType.Tag, parameterList);
                        GetParametersInNode(containsNode, Caml.Constants.Contains.ValueType.Tag, parameterList);
                        break;
                    }
                case CamlTypes.UpdateListItems:
                    {
                        if (batchNode == null)
                        {
                            return null;
                        }
                        GetParametersInNode(batchNode, Caml.Constants.Batch.Method.Field.Tag, parameterList);
                        break;
                    }
            }

            return parameterList;
        }

        private void GetParametersInNode(XmlNode node, string tag, List<CamlParameter> parameterList)
        {
            if (node == null)
            {
                return;
            }
            XmlNodeList nodeList = node.SelectNodes("//" + tag);
            foreach (XmlNode childNode in nodeList)
            {
                string parameterName = childNode.InnerText;
                if (parameterName.StartsWith("[") && parameterName.EndsWith("]"))
                {
                    CamlParameter p = new CamlParameter(parameterName, null);
                    parameterList.Add(p);
                }
            }
        }

        public List<CamlParameter> GetEmptyParameterStructure(XmlDocument camlDocument)
        {
            this.camlDocument = camlDocument;
            GetCamlNodes();

            return GetEmptyParameterStructure();
        }

        public void ReplaceDateTimeParameterValues(ref List<CamlParameter> camlParameters)
        {
            string parameter = "//" + Caml.Constants.Query.Where.ValueType.Tag + "[. = '{0}']";
            foreach (CamlParameter p in camlParameters)
            {
                XmlNode node = camlDocument.SelectSingleNode(string.Format(parameter, p.ParameterName));
                if (node != null)
                {
                    DateTime calculatedDate = new DateTime(1900, 1, 1);
                    if (p.ParameterName.Substring(1, 5) == "Today")
                    {
                        calculatedDate = DateTime.Today;
                    }
                    else if (p.ParameterName.Substring(1, 3) == "Now")
                    {
                        calculatedDate = DateTime.Now;
                    }
                    else if (p.ParameterName.IndexOf("+") > -1)
                    {
                        calculatedDate = DateTime.Parse(p.ParameterName.Substring(1, p.ParameterName.IndexOf("+") - 1));
                    }
                    else if (p.ParameterName.IndexOf("-") > -1)
                    {
                        calculatedDate = DateTime.Parse(p.ParameterName.Substring(1, p.ParameterName.IndexOf("-") - 1));
                    }
                    else
                    {
                        continue;
                    }

                    while (p.ParameterName.IndexOf("+") > -1 || p.ParameterName.IndexOf("-") > -1)
                    {
                        int digitcounter = 0;
                        string sign = null;
                        string periods = null;
                        string periodtype = null;

                        // get the + or the - sign
                        if (p.ParameterName.IndexOf("+") > -1 && p.ParameterName.IndexOf("-") > -1 && p.ParameterName.IndexOf("+") < p.ParameterName.IndexOf("-"))
                        {
                            sign = "+";
                        }
                        else if (p.ParameterName.IndexOf("+") > -1 && p.ParameterName.IndexOf("-") > -1 && p.ParameterName.IndexOf("-") < p.ParameterName.IndexOf("+"))
                        {
                            sign = "-";
                        }
                        else if (p.ParameterName.IndexOf("+") > -1)
                        {
                            sign = "+";
                        }
                        else
                        {
                            sign = "-";
                        }

                        string reststring = null;
                        if (p.ParameterName.IndexOf("+", p.ParameterName.IndexOf(sign) + 1) == -1 && p.ParameterName.IndexOf("-", p.ParameterName.IndexOf(sign) + 1) == -1)
                            reststring = p.ParameterName.Substring(p.ParameterName.IndexOf(sign) + 1, p.ParameterName.Length - p.ParameterName.IndexOf(sign) - 2);
                        else if (p.ParameterName.IndexOf("+", p.ParameterName.IndexOf(sign) + 1) > -1)
                            reststring = p.ParameterName.Substring(p.ParameterName.IndexOf(sign) + 1, p.ParameterName.IndexOf("+", p.ParameterName.IndexOf(sign) + 1) - p.ParameterName.IndexOf(sign) - 1);
                        else
                            reststring = p.ParameterName.Substring(p.ParameterName.IndexOf(sign) + 1, p.ParameterName.IndexOf("-", p.ParameterName.IndexOf(sign) + 1) - p.ParameterName.IndexOf(sign) - 1);

                        // get the periods that need to be added or subtracted
                        for (digitcounter = 0; digitcounter < reststring.Length; digitcounter++)
                        {
                            if (U2U.UtilityFunctions.Math.IsNumeric(reststring.Substring(digitcounter, 1)))
                            {
                                periods += reststring.Substring(digitcounter, 1);
                            }
                            else
                            {
                                break;
                            }
                        }
                        // get the type of period
                        periodtype = reststring.Substring(digitcounter, reststring.Length - digitcounter);

                        double dblperiods = 0.0;
                        int intperiods = 0;
                        if (sign == "+")
                        {
                            dblperiods = Double.Parse(periods);
                            intperiods = Int32.Parse(periods);
                        }
                        else
                        {
                            dblperiods = Double.Parse(periods) * -1;
                            intperiods = Int32.Parse(periods) * -1;
                        }

                        switch (periodtype)
                        {
                            case "Day(s)":
                                {
                                    calculatedDate = calculatedDate.AddDays(dblperiods);
                                    break;
                                }
                            case "Month(s)":
                                {
                                    calculatedDate = calculatedDate.AddMonths(intperiods);
                                    break;
                                }
                            case "Year(s)":
                                {
                                    calculatedDate = calculatedDate.AddYears(intperiods);
                                    break;
                                }
                            case "Hours(s)":
                                {
                                    calculatedDate = calculatedDate.AddHours(intperiods);
                                    break;
                                }
                            case "Minute(s)":
                                {
                                    calculatedDate = calculatedDate.AddMinutes(dblperiods);
                                    break;
                                }
                            case "Second(s)":
                                {
                                    calculatedDate = calculatedDate.AddSeconds(dblperiods);
                                    break;
                                }
                            default:
                                {
                                    throw new Exception("The DateTime parameter is invalid");
                                    //break;
                                }
                        }

                        // remove the handled part of the parameterName
                        p.ParameterName = p.ParameterName.Substring(p.ParameterName.IndexOf(sign) + 1);
                    }

                    // replace the parameter by the calculated date
                    node.InnerText = U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(calculatedDate);
                }
            }
        }

        #endregion

    }
}
