using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCFolderProtection.Startup))]
namespace MVCFolderProtection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
