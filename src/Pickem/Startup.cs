using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pickem.Startup))]
namespace Pickem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
