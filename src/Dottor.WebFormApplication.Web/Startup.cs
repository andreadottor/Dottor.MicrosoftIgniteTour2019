using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dottor.WebFormApplication.Web.Startup))]
namespace Dottor.WebFormApplication.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
