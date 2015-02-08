using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorldMerchants.Startup))]
namespace WorldMerchants
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
