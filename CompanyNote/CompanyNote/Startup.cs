using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompanyNote.Startup))]
namespace CompanyNote
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
