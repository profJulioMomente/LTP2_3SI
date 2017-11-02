using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LTP2_NparaN.Startup))]
namespace LTP2_NparaN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
