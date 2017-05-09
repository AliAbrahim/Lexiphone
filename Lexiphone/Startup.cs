using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lexiphone.Startup))]
namespace Lexiphone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
