using PDCore.Repositories.Repo;
using PDCoreNew.Services.Serv;
using PDWebCore.Helpers.ExceptionHandling;
using PDWebCore.Helpers.MultiLanguage;
using PDWebCore.Loggers;
using Pumox.Test.DAL;
using System;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace Pumox.Test.Web
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ContainerConfig.RegisterContainer(GlobalConfiguration.Configuration);

            log4net.Config.XmlConfigurator.Configure();

            LogService.EnableLogInDb<PumoxTestContext, SqlServerWebLogger>();

            SqlRepository.IsLoggingEnabledByDefault = bool.Parse(WebConfigurationManager.AppSettings["IsLoggingEnabledByDefault"]);
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
