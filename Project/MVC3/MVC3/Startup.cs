using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC3.Startup))]
namespace MVC3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
