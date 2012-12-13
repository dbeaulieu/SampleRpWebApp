using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SampleRpWebApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
        }

        void WSFederationAuthenticationModule_SessionSecurityTokenCreated(object sender, SessionSecurityTokenCreatedEventArgs e)
        {
            //Manipulate session token here, for example, changing its expiration value
            System.Diagnostics.Trace.WriteLine("Handling SessionSecurityTokenCreated event");
            System.Diagnostics.Trace.WriteLine("Key valid from: " + e.SessionToken.KeyEffectiveTime);
            System.Diagnostics.Trace.WriteLine("Key expires on: " + e.SessionToken.KeyExpirationTime);
            e.SessionToken.IsReferenceMode = true;
        }

        private void WSFederationAuthenticationModule_SignedOut(object sender, EventArgs e)
        {
            Response.Redirect("~/CleanUp.aspx", false);
        }
    }
}