using System;
using System.IO;
using System.Xml;

namespace U2U.UtilityFunctions
{
    /// <summary>
    /// Summary description for UtilityFunctionsCAML.
    /// </summary>
    public class CAML
    {
        public static U2U.SharePoint.CAML.Enumerations.DataTypes ConvertToDataType(string dataType)
        {
            Type t = typeof(U2U.SharePoint.CAML.Enumerations.DataTypes);
            foreach (System.Reflection.FieldInfo fi in t.GetFields())
            {
                if (fi.Name == dataType)
                    return (U2U.SharePoint.CAML.Enumerations.DataTypes)fi.GetValue(null);
            }
            return U2U.SharePoint.CAML.Enumerations.DataTypes.Text;
        }

        public static string CreateISO8601DateTimeFromSystemDateTime(DateTime date)
        {
            // TODO: check ivm utd date
            // a sharePoint datetime is from the format yyyy-MM-ddThh:mm:ssZ

            string s = string.Format(System.Globalization.CultureInfo.InvariantCulture, date.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            return s;
        }

        public static DateTime? CreateDateFromISO8601DateTime(string isodate)
        {
            // a sharePoint datetime is from the format yyyy-MM-ddThh:mm:ssZ
            if (isodate.Length == 20 && isodate.Substring(4, 1) == "-" && isodate.Substring(7, 1) == "-"
                && isodate.Substring(10, 1) == "T" && isodate.Substring(19, 1) == "Z")
            {
                int year;
                int.TryParse(isodate.Substring(0, 4), out year);
                int month;
                int.TryParse(isodate.Substring(5, 2), out month);
                int day;
                int.TryParse(isodate.Substring(8, 2), out day);
                DateTime date = new DateTime(year, month, day);
                return date;
            }
            else
                return null;
        }

        #region OpenCAMLFile

        public static XmlDocument OpenCAMLFile(string camlFile, ref string connectionType, ref string uriVirtualServer, ref bool isCustomCredentials,
            ref string userName, ref string password, ref string domain, ref string listName, ref string listGuid)
        {
            XmlDocument camlDocument = null;
            // open the file and get the data
            FileInfo file = new FileInfo(camlFile);
            if (file.Exists)
            {
                TextReader sr = null;
                try
                {
                    sr = new StreamReader(camlFile);
                    if (sr == null)
                        throw new ApplicationException("The file cannot be opened");
                    // get the SharePoint url
                    string text = sr.ReadLine();
                    if (text != string.Empty)
                        uriVirtualServer = text;
                    if ((uriVirtualServer == null || uriVirtualServer == string.Empty))
                        throw new ApplicationException("The file has an incorrect format.");
                    // this string contains a letter s(erver) or c(lient) and the uri
                    string connectiontype = uriVirtualServer.Substring(0, uriVirtualServer.IndexOf("|"));
                    uriVirtualServer = uriVirtualServer.Substring(uriVirtualServer.IndexOf("|") + 1, uriVirtualServer.Length - uriVirtualServer.IndexOf("|") - 1);
                    // check the user credentials
                    string credentialString = sr.ReadLine();
                    if (credentialString != string.Empty)
                    {
                        string[] credentials = credentialString.Split('|');
                        if (credentials.Length == 3)
                        {
                            isCustomCredentials = true;
                            userName = credentials[0];
                            password = U2U.UtilityFunctions.Encryption.DecryptData(credentials[1]);
                            domain = credentials[2];
                        }
                    }

                    // get the listname
                    text = sr.ReadLine();
                    if (text != string.Empty)
                    {
                        listName = text.Substring(0, text.IndexOf("|"));
                        listGuid = text.Substring(text.IndexOf("|") + 1, text.Length - text.IndexOf("|") - 1);
                    }

                    // get the CAML
                    text = sr.ReadLine();
                    if (text != null)
                        camlDocument = new XmlDocument();
                    camlDocument.LoadXml(text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (sr != null)
                        sr.Close();
                }
            }
            else
            {
                throw new FileNotFoundException("CAML file not found.", camlFile);
            }
            return camlDocument;
        }

        #endregion
    }
}
