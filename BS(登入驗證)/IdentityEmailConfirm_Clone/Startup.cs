using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityEmailConfirm_Clone.Startup))]
namespace IdentityEmailConfirm_Clone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
