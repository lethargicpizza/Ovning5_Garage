using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(STAS.Startup))]
namespace STAS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
