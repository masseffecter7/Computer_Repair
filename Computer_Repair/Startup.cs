using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Computer_Repair.Startup))]
namespace Computer_Repair
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
