using Autofac;
using Autofac.Integration.Mvc;
using BUOTOnline.DAL.Modules;
using BUOTOnline.Web.Models;
using System.Reflection;
using System.Web.Mvc;

namespace BUOTOnline.Web.App_Start
{
    public static class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule<ServiceModule>();

            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}