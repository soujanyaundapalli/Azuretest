using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proficiencytoday.Startup))]
namespace proficiencytoday
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
