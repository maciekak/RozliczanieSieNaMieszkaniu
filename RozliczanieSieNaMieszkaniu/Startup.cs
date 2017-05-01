using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RozliczanieSieNaMieszkaniu.Startup))]
namespace RozliczanieSieNaMieszkaniu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
