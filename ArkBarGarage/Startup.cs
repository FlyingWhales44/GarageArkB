using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArkBarGarage.Startup))]
namespace ArkBarGarage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
