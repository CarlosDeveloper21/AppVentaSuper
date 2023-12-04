using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppVentaSuper.Startup))]
namespace AppVentaSuper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
