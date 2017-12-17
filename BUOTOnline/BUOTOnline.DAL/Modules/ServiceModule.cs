using Autofac;
using BUOTOnline.DAL.IServices;
using BUOTOnline.DAL.Services;

namespace BUOTOnline.DAL.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>()
                .As<ICategoryService>()
                .InstancePerLifetimeScope();
        }
    }
}
