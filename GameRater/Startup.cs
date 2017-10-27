using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameRater.Startup))]
namespace GameRater
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
