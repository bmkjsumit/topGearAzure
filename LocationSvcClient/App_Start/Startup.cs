using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Owin;
using Owin;

using Microsoft.Owin.Security.ActiveDirectory;
using Microsoft.Owin.Security.Cookies;
using System.Configuration;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Owin.Security;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

[assembly: OwinStartup(typeof(LocationSvcClient.App_Start.Startup))]
namespace LocationSvcClient.App_Start
{
    public partial class Startup
    {
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string appKey = ConfigurationManager.AppSettings["ida:appKey"];
        private static string aadInstance = ConfigurationManager.AppSettings["ida:aadInstance"];
        private static string tenant = ConfigurationManager.AppSettings["ida:tenant"];
        private static string postLogoutRedirectUri = ConfigurationManager.AppSettings["ida:postLogoutRedirectUri"];
        private static string serviceResourceID = ConfigurationManager.AppSettings["ida:serviceResourceID"];        

        string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = clientId,
                    Authority = authority,
                    PostLogoutRedirectUri = postLogoutRedirectUri,
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthorizationCodeReceived = (context) =>
                        {
                            var code = context.Code;
                            ClientCredential credential = new ClientCredential(clientId, appKey);
                            string userObjectID =
                                context.AuthenticationTicket.Identity.FindFirst(
                                    "http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
                            AuthenticationContext authContext = new AuthenticationContext(authority, new WebSessionCache(userObjectID));
                            AuthenticationResult result = authContext.AcquireTokenByAuthorizationCode(code,
                                new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path)), credential, serviceResourceID);
                            return Task.FromResult(0);
                        },
                        AuthenticationFailed = context =>
                        {
                            context.HandleResponse();
                            context.Response.Redirect("/Home/Error");
                            return Task.FromResult(0);
                        }
                    }
                });
        }
    }
}