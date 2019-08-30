using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyPractice.Startup))]
namespace VidlyPractice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
