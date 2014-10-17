using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jukebox.Startup))]
namespace Jukebox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
