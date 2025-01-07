using System;
using System.Reflection;
using System.Runtime.CompilerServices;

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle("U2U Caml SharePoint Library")]
[assembly: AssemblyDescription("U2U CAML Query Builder")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("U2U")]
[assembly: AssemblyProduct("U2U CAML Query Builder")]
[assembly: AssemblyCopyright("Copyright U2U 2008")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion("4.4.0.0")]
[assembly: AssemblyFileVersion("4.4.0.0")]
[assembly: CLSCompliant(true)]

//
// In order to sign your assembly you must specify a key to use. Refer to the 
// Microsoft .NET Framework documentation for more information on assembly signing.
//
// Use the attributes below to control which key is used for signing. 
//
// Notes: 
//   (*) If no key is specified, the assembly is not signed.
//   (*) KeyName refers to a key that has been installed in the Crypto Service
//       Provider (CSP) on your machine. KeyFile refers to a file which contains
//       a key.
//   (*) If the KeyFile and the KeyName values are both specified, the 
//       following processing occurs:
//       (1) If the KeyName can be found in the CSP, that key is used.
//       (2) If the KeyName does not exist and the KeyFile does exist, the key 
//           in the KeyFile is installed into the CSP and used.
//   (*) In order to create a KeyFile, you can use the sn.exe (Strong Name) utility.
//       When specifying the KeyFile, the location of the KeyFile should be
//       relative to the project output directory which is
//       %Project Directory%\obj\<configuration>. For example, if your KeyFile is
//       located in the project directory, you would specify the AssemblyKeyFile 
//       attribute as [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) Delay Signing is an advanced option - see the Microsoft .NET Framework
//       documentation for more information on this.
//
[assembly: AssemblyDelaySign(false)]
[assembly: InternalsVisibleTo("U2U.SharePoint.CAML.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100677d32ec20808f636f6a9d31799455f7288670edbfb7ebbd4a9a823a26b092cef15b468e4bde391356b1cfe3b8abbc7b6a99fc15b80eab96c95ef59ecd4c8cdf5f850e36bfc214ed4ddbc214566148d077326c736ace7bf38cfb8a545fed7788f2bdb30e224e11d2e115fe70bf341c498957e5ccb65138f0cf372f75577f92a5")]
[assembly: InternalsVisibleTo("U2U.SharePoint.CAML.Explorables, PublicKey=0024000004800000940000000602000000240000525341310004000001000100677d32ec20808f636f6a9d31799455f7288670edbfb7ebbd4a9a823a26b092cef15b468e4bde391356b1cfe3b8abbc7b6a99fc15b80eab96c95ef59ecd4c8cdf5f850e36bfc214ed4ddbc214566148d077326c736ace7bf38cfb8a545fed7788f2bdb30e224e11d2e115fe70bf341c498957e5ccb65138f0cf372f75577f92a5")]
