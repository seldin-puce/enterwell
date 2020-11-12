using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Invoice.Web.Startup))]
namespace Invoice.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}