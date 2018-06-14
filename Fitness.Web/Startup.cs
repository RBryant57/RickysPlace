using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessWeb.Startup))]
namespace FitnessWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
