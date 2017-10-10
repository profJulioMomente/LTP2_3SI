using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LTP2_MVC_Exemplo.Startup))]
namespace LTP2_MVC_Exemplo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
