# CAML Query Builder

The U2U CAML Query Builder is a tool designed to help developers create and test CAML (Collaborative Application Markup Language) queries for SharePoint.

Created a long time ago in an older version of the .NET Framework, this tool became popular with many SharePoint developers. Over the years, many changes and updates have been made. We added support for CSOM, SharePoint Online, and multifactor authentication while actually having limited time to do so, which sometimes resulted in sub-optimal code.

SharePoint has also changed a lot, and writing CAML queries has become less and less necessary. So the time has come to stop supporting and updating this tool and release the code to the world. It is yours to use.

There are two versions of the CAML Query Builder:

## On-Premise Version
This version runs on .NET Framework 4.6.2. It can be used with SharePoint on-premise and online but does not support Multifactor authentication.

## Online Version
This version runs on .NET 6. Can be used with SharePoint Online, with or without multifactor authentication.