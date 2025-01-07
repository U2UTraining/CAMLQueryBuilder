using System;
using System.Collections;

namespace U2U.CamlControlLibrary
{
	/// <summary>
	/// Summary description for GuiObjects.
	/// </summary>
	#region FieldObject
	public class FieldObject
	{
        Guid _id;
		string _displayName;
		string _internalName;
		string _typeAsString;
		string _lookupList;
		string _showField;
		string _defaultChoice;
		string _choiceList;
		string _fieldValue;

		public FieldObject(string displayName, Guid id, string internalName, string typeAsString)
		{
            _id = id;
			_displayName = displayName;
			_internalName = internalName;
			_typeAsString = typeAsString;
		}

		public FieldObject(string displayName, Guid id, string internalName, string typeAsString, string fieldValue): 
            this(displayName, id, internalName, typeAsString)
		{
			_fieldValue = fieldValue;
		}

        public Guid ID
        {
            get { return _id; }
        }

        public string DisplayName
		{
			get { return _displayName; }
		}

		public string InternalName
		{
			get { return _internalName; }
		}

		public string TypeAsString
		{
			get { return _typeAsString; }
            set { _typeAsString = value; }
        }

		public string FieldValue
		{
			get { return _fieldValue; }
			set { _fieldValue = value; }
		}

		public string LookupList
		{
			get { return _lookupList; }
			set { _lookupList = value; }
		}

		public string ShowField
		{
			get { return _showField; }
			set { _showField = value; }
		}

		public string DefaultChoice
		{
			get { return _defaultChoice; }
			set { _defaultChoice = value; }
		}

		public string ChoiceList
		{
			get { return _choiceList; }
			set { _choiceList = value; }
		}

		public override string ToString()
		{
			return _displayName;
		}
	}
	#endregion

	#region ViewObject
	public class ViewObject
	{
		string _displayName;
		string _internalName;

		public ViewObject(string displayName, string internalName)
		{
			_displayName = displayName;
			_internalName = internalName;
		}

		public string DisplayName
		{
			get { return _displayName; }
		}

		public string InternalName
		{
			get { return _internalName; }
		}
		public override string ToString()
		{
			return _displayName;
		}
	}
	#endregion

	#region MethodObject
	public class MethodObject
	{
		string _id;
		string _command;
		ArrayList _fieldObjects;

		public MethodObject(string id, string command)
		{
			_id = id;
			_command = command;
		}

		public string ID
		{
			get { return _id; }
		}

		public string Command
		{
			get { return _command; }
			set { _command = value; }
		}

		public FieldObject[] FieldObjects
		{
			get 
			{
				if (_fieldObjects != null)
					return (FieldObject[])_fieldObjects.ToArray(typeof(FieldObject)); 
				else
					return null;
			}
		}

		public void AddFieldObject(FieldObject fieldObject)
		{
			if (fieldObject == null) return;
			if (_fieldObjects == null)
				_fieldObjects = new ArrayList();
			_fieldObjects.Add(fieldObject);
		}

		public void RemoveFieldObject(FieldObject fieldObject)
		{
			if (fieldObject == null) return;
			_fieldObjects.Remove(fieldObject);
		}

		public override string ToString()
		{
			return "Method ID=" + _id;
		}
	}
	#endregion
}
