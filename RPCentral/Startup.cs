using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RPCentral.Startup))]
namespace RPCentral
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
