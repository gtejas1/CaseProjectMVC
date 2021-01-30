using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaseProjectMVC.Startup))]
namespace CaseProjectMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
