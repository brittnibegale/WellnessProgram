using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WellnessProject.Startup))]
namespace WellnessProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
