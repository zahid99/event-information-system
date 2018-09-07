using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventManagementInformation.Startup))]
namespace EventManagementInformation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
