using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpyGame.Startup))]
namespace SpyGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
