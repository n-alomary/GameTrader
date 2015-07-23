using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameTrader.Startup))]
namespace GameTrader
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
