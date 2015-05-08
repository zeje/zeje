using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zeje.Sys.Startup))]
namespace Zeje.Sys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
