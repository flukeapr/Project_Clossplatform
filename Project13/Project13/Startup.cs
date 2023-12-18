using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project13.Startup))]
namespace Project13
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
