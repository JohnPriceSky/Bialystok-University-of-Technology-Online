using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BUOTOnline.DAL.Modules;
using BUOTOnline.Web.Models;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace BUOTOnline.Web.App_Start
{
    public static class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule<ServiceModule>();

            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}