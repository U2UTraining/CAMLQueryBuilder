using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace U2U.SharePoint
{
	/// <summary>
	/// Summary description for UtilityFunctionsSecurity.
	/// </summary>
	public class Security
	{
		#region Impersonation
		public static WindowsIdentity CreateIdentity(string User, string Domain, string Password)
		{
			// The Windows NT user token.
			IntPtr tokenHandle = new IntPtr(0);

			const int LOGON32_PROVIDER_DEFAULT = 0;
			const int LOGON32_LOGON_NETWORK = 3;

			tokenHandle = IntPtr.Zero;

			// Call LogonUser to obtain a handle to an access token.
			bool returnValue = LogonUser(User, Domain, Password,
				LOGON32_LOGON_NETWORK, LOGON32_PROVIDER_DEFAULT,
				ref tokenHandle);

			if (false == returnValue)
			{
				int ret = Marshal.GetLastWin32Error();
				throw new Exception("LogonUser failed with error code: " +  ret);
			}

			System.Diagnostics.Debug.WriteLine("Created user token: " + tokenHandle);

			//The WindowsIdentity class makes a new copy of the token.
			//It also handles calling CloseHandle for the copy.
			WindowsIdentity id = new WindowsIdentity(tokenHandle);
			CloseHandle(tokenHandle);
			return id;
		}

		[DllImport("advapi32.dll", SetLastError=true)]
		private static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
			int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

		[DllImport("kernel32.dll", CharSet=CharSet.Auto)]
		private extern static bool CloseHandle(IntPtr handle);		

		#endregion
	}
}
