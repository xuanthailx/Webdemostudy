using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demostudyweb.Startup))]
namespace Demostudyweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
