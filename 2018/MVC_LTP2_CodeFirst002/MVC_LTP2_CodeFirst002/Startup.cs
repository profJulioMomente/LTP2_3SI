using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_LTP2_CodeFirst002.Startup))]
namespace MVC_LTP2_CodeFirst002
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
