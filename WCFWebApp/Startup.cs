using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WCFWebApp.Startup))]
namespace WCFWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
