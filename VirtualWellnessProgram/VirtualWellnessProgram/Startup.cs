using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VirtualWellnessProgram.Startup))]
namespace VirtualWellnessProgram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
