using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Recaptcha;
using SNet.Web.App_Start;
using SNet.Web.DependencyResolution;

namespace SNet.Web
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

            
            RecaptchaControlMvc.PrivateKey = "6Lds89QSAAAAADxKjN8N9jxwyzmx_WkXXo7YBA6D";
            RecaptchaControlMvc.PublicKey = "6Lds89QSAAAAAHgyt0U3UGeNITSvKfPS2M5a-uRp";
        }

    }
}