using PDWebCore.Helpers.ExceptionHandling;
using PDWebCore.Helpers.MultiLanguage;
using System;
using System.Web;
using System.Web.Http;

namespace Pumox.Test.Web
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            HttpApplicationErrorHandler.HandleLastException(Server, Request, Response);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            LanguageHelper.SetLanguage(Request);
        }
    }
}
