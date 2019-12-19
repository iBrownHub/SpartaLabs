using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab_29_MVC.Startup))]
namespace Lab_29_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
