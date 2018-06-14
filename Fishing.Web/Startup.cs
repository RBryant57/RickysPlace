using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fishing.Web.Startup))]
namespace Fishing.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
