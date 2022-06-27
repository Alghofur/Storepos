using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Storepos.Startup))]
namespace Storepos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        
    }
}
