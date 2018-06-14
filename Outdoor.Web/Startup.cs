using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Outdoor.Web.Startup))]
namespace Outdoor.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
