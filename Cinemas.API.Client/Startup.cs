using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cinemas.API.Client.Startup))]
namespace Cinemas.API.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
