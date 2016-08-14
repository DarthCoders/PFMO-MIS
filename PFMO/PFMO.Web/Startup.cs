using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PFMO.Web.Startup))]
namespace PFMO.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
