using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcIdentityUserRole_Clone.Startup))]
namespace MvcIdentityUserRole_Clone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
