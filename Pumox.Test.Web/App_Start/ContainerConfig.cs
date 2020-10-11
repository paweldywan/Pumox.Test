using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using CommonServiceLocator;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PDCore.Factories.Fac;
using PDCore.Factories.IFac;
using PDCore.Interfaces;
using PDCore.Repositories.IRepo;
using PDCoreNew.Context.IContext;
using PDCoreNew.Factories.Fac.Repository;
using PDCoreNew.Helpers;
using PDCoreNew.Loggers;
using PDCoreNew.Repositories.Repo;
using PDWebCore.Context.IContext;
using PDWebCore.Models;
using Pumox.Test.BLL.Translators;
using Pumox.Test.DAL;
using Pumox.Test.DAL.Contracts;
using Pumox.Test.DAL.Entities;
using Pumox.Test.DAL.Strategies;
using System.Data.Entity;
using System.Security.Principal;
using System.Web.Http;

namespace Pumox.Test.Web
{
    public class ContainerConfig
    {
        private static void RegisterServices(ContainerBuilder builder)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PumoxTestMappingProfile());
            });

            builder.RegisterInstance(mapperConfiguration.CreateMapper())
                   .As<IMapper>()
                   .SingleInstance();


            builder.RegisterGeneric(typeof(PumoxTestDataAccessStrategy<>))
                   .As(typeof(IDataAccessStrategy<>))
                   .SingleInstance();


            builder.RegisterType<ApplicationUserManager>()
                   .InstancePerRequest();

            builder.RegisterType<UserStore<ApplicationUser>>()
                   .As<IUserStore<ApplicationUser>>()
                   .UsingConstructor(typeof(DbContext))
                   .InstancePerRequest();

            builder.RegisterType<HttpContextPrinciple>()
                   .As<IPrincipal>()
                   .SingleInstance();


            builder.RegisterType<PumoxTestContext>()
                   .As<IEntityFrameworkDbContext>()
                   .As<IMainDbContext>()
                   .As<IMainWebDbContext>()
                   .As<DbContext>();

            builder.RegisterType<RepositoryFactories>()
                   .AsSelf()
                   .SingleInstance();

            builder.RegisterType<RepositoryProvider>()
                   .As<IRepositoryProvider>()
                   .InstancePerRequest();

            builder.RegisterType<PumoxTestUow>()
                   .As<IPumoxTestUow>()
                   .InstancePerRequest();


            builder.RegisterGeneric(typeof(SqlRepositoryEntityFrameworkDisconnected<>))
                   .As(typeof(ISqlRepositoryEntityFrameworkDisconnected<>))
                   .InstancePerRequest();


            builder.RegisterType<LogMessageFactory>()
                   .As<ILogMessageFactory>()
                   .SingleInstance();


            builder.RegisterType<ConsoleLogger>()
                   .As<ILogger>()
                   .SingleInstance();


            builder.RegisterType<PumoxTestTranslator>()
                   .AsSelf()
                   .SingleInstance();
        }

        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            RegisterServices(builder);


            var container = builder.Build();


            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
