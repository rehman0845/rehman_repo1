using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularCrud.Startup))]
namespace AngularCrud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
