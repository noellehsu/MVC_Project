using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc_IdentityUserRole.Startup))]
namespace Mvc_IdentityUserRole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
