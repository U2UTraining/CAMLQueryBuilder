using Microsoft.Identity.Client;
using Microsoft.SharePoint.Client;
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace U2U.SharePoint.CAML.O365Helpers
{
    public static class MSALClaimsHelper
    {
        static string siteUrl;
        static string domainUrl;
        static string[] scopes;
        static string token = string.Empty;

        public static bool Initialized { get; set; }

        public static async Task Init(string siteUrl)
        {
            if (Initialized)
            {
                return;
            }
            MSALClaimsHelper.siteUrl = siteUrl;
            domainUrl = GetDomainUrl(siteUrl);
            scopes = new[] { $"{domainUrl}/.default" };
            var clientId = ConfigurationManager.AppSettings["clientId"];
            var redirectUri = ConfigurationManager.AppSettings["redirectUri"];
            var app = PublicClientApplicationBuilder.Create(clientId)
                .WithRedirectUri(redirectUri)
                .Build();

            try
            {
                var authResult = await app.AcquireTokenInteractive(scopes)
                                 .WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
                                .ExecuteAsync().ConfigureAwait(false);

                token = authResult.AccessToken;
                Initialized = true;

            }
            catch (MsalException msalex)
            {
                Console.WriteLine($"Authentication Failure: {msalex.Message}");
            }
        }

        public static void clientContext_ExecutingWebRequest(object sender, WebRequestEventArgs e)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("MSALClaimsHelper was not initialized");
            }
            e.WebRequestExecutor.RequestHeaders["Authorization"] = "Bearer " + token;
        }

        public async static Task<string> GetAccessToken(string siteUrl)
        {
            if (string.IsNullOrEmpty(token))
            {
                await Init(siteUrl);
            }

            return token;
        }

        public static string GetDomainUrl(string siteUrl)
        {
            if (siteUrl.EndsWith("/"))
            {
                siteUrl = siteUrl.Substring(0, siteUrl.Length - 1);
            }
            var nrOfSlashes = siteUrl.Aggregate("", (a, b) => b == '/' ? a + b : a).Length;
            if (nrOfSlashes == 2)
            {
                return siteUrl;
            }
            else
            {
                var x = siteUrl.Substring(8).IndexOf('/') + 8;
                return siteUrl.Substring(0, x);
            }

        }
    }
}
