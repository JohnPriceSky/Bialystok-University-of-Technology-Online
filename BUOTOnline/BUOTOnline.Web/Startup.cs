using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BUOTOnline.Web.Startup))]
namespace BUOTOnline.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
