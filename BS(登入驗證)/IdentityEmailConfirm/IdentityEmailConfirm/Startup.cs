using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityEmailConfirm.Startup))]
namespace IdentityEmailConfirm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
