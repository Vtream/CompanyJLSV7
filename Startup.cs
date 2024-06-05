using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompanyJLSV7.Startup))]
namespace CompanyJLSV7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
