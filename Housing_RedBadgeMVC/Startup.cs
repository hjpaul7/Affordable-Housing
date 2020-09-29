using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Housing_RedBadgeMVC.Startup))]
namespace Housing_RedBadgeMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
