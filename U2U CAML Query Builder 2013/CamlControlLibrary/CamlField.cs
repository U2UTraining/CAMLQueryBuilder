using System;
using System.Xml;

namespace U2U.CamlControlLibrary
{
	public class WhereField
	{
		public XmlNode FieldNode;
        public Guid ID;
		public string FieldRef;
		public int OperatorIndex;
		public string DataType;
		public string Value;

		public WhereField()
		{
		}
		public WhereField(string fieldRef, Guid id, int operatorIndex, string fieldValue, string dataType, XmlNode fieldNode)
		{
			this.FieldRef = fieldRef;
            this.ID = id;
			this.OperatorIndex = operatorIndex;
			this.Value = fieldValue;
			this.DataType = dataType;
			this.FieldNode = fieldNode;
		}
	}

	public class OrderField
	{
		public string FieldRef;
        public Guid ID;
        public int OrderByIndex;
		public XmlNode FieldNode;

		public OrderField()
		{
		}
        public OrderField(string fieldRef, Guid id, int orderbyIndex, XmlNode fieldNode)
		{
			this.FieldRef = fieldRef;
            this.ID = id;
			this.OrderByIndex = orderbyIndex;
			this.FieldNode = fieldNode;
		}
	}
}
