namespace U2U.SharePoint.CAML
{
    /// <summary>
    /// Summary description for CamlParameter.
    /// </summary>
    public class CamlParameter
    {
        string _parameterName;
        string _parameterValue;

        public CamlParameter()
        {
        }

        public CamlParameter(string parameterName, string parameterValue)
        {
            _parameterName = parameterName;
            _parameterValue = parameterValue;
        }

        public string ParameterName
        {
            get { return _parameterName; }
            set { _parameterName = value; }
        }

        public string ParameterValue
        {
            get { return _parameterValue; }
            set { _parameterValue = value; }
        }
    }
}
