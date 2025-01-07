using System;

namespace U2U.UtilityFunctions
{
	/// <summary>
	/// Summary description for UtilityFunctionsMath.
	/// </summary>
	public class Math
	{
		public static bool IsNumeric(string s)
		{
			try 
			{
				Int32.Parse(s);
			}
			catch 
			{
				return false;
			}
			return true;
		}
	}
}
