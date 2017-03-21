using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndentitySecurity.Startup))]
namespace IndentitySecurity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
