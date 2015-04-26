using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zeje.WX.Startup))]
namespace Zeje.WX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
