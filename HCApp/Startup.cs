using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HCApp.Startup))]
namespace HCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
