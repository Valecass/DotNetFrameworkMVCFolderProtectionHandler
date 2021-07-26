using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetFrameworkMVCFolderProtection.Startup))]
namespace DotNetFrameworkMVCFolderProtection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
