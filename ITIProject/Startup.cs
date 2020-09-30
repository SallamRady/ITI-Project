using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITIProject.Startup))]
namespace ITIProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
