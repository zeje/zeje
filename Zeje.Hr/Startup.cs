using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zeje.Hr.Startup))]
namespace Zeje.Hr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
