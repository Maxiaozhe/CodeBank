using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IPOEM.Startup))]
namespace IPOEM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
