using Microsoft.Web.Http;
using Microsoft.Web.Http.Versioning;
using Newtonsoft.Json;
using PDCore.Repositories.Repo;
using PDCoreNew.Services.Serv;
using PDWebCore.Filters.WebApi;
using PDWebCore.Handlers;
using PDWebCore.Helpers.ModelBinding.WebApi;
using PDWebCore.Loggers;
using Pumox.Test.BLL.Models;
using Pumox.Test.DAL;
using System;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Pumox.Test.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Replace(typeof(IExceptionHandler), new LogExceptionHandler());

            config.BindParameter(typeof(DateTime), new UtcDateTimeModelBinder());
            config.BindParameter(typeof(DateTime?), new UtcDateTimeModelBinder());

            // Web API configuration and services

            config.AddApiVersioning(cfg =>
            {
                cfg.DefaultApiVersion = new ApiVersion(1, 0);
                cfg.AssumeDefaultVersionWhenUnspecified = true;
                cfg.ReportApiVersions = true;
                cfg.ApiVersionReader = ApiVersionReader.Combine(
                                        new HeaderApiVersionReader("X-Version"),
                                        new QueryStringApiVersionReader("ver"));
            });

            // Remove Xml formatters. This means when we visit an endpoint from a browser,
            // Instead of returning Xml, it will return Json.
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Use camel case for JSON data.
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Convert all dates to UTC;
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            // Add model validation, globally
            config.Filters.Add(new ValidationActionFilterAttribute());

            //config.Filters.Add(new ModelValidateNotNullFilterAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            DefineRoutes(config);


            ContainerConfig.RegisterContainer(config);

            LogService.EnableLogInDb<PumoxTestContext, SqlServerWebLogger>();

            log4net.Config.XmlConfigurator.Configure();

            SqlRepository.IsLoggingEnabledByDefault = bool.Parse(WebConfigurationManager.AppSettings["IsLoggingEnabledByDefault"]);
        }

        private static void DefineRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
