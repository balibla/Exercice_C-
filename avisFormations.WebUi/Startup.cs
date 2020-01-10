using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(avisFormations.WebUi.Startup))]
namespace avisFormations.WebUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
