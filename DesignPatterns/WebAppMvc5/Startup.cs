using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppMvc5.Startup))]
namespace WebAppMvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
