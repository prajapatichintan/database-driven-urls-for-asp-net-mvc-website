using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DynamicRoutingExample.Startup))]
namespace DynamicRoutingExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
