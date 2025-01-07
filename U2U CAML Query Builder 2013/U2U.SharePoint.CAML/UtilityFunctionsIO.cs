using System;
using System.IO;
using System.Security.Cryptography;

namespace U2U.UtilityFunctions
{
	/// <summary>
	/// Summary description for UtilityFunctions.
	/// </summary>
	public class IO
	{
		public static void CopyDirectory(string sourceDirectory, string targetDirectory)
		{
			if (targetDirectory[targetDirectory.Length-1] != Path.DirectorySeparatorChar)
				targetDirectory += Path.DirectorySeparatorChar;

			if (!Directory.Exists(targetDirectory))
				Directory.CreateDirectory(targetDirectory);

			string[] files = Directory.GetFileSystemEntries(sourceDirectory);

			foreach (string f in files)
			{
				if(Directory.Exists(f))
					CopyDirectory(f, targetDirectory + Path.GetFileName(f));
				else
					File.Copy(f, targetDirectory + Path.GetFileName(f), true);
			}
		}
	}

}

