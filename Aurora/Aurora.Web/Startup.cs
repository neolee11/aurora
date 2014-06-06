using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aurora.Web.Startup))]
namespace Aurora.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
