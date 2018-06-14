using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tech.Web.Startup))]
namespace Tech.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
