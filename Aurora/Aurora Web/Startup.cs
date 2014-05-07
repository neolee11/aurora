using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aurora_Web.Startup))]
namespace Aurora_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
