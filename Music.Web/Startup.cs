using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Music.Web.Startup))]
namespace Music.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
