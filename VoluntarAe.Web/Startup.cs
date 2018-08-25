using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VoluntarAe.Web.Startup))]
namespace VoluntarAe.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
