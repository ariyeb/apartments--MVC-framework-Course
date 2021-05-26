using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Apartments__MVC_Course.Startup))]
namespace Apartments__MVC_Course
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
