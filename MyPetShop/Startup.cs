using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyPetShop.Startup))]
namespace MyPetShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
