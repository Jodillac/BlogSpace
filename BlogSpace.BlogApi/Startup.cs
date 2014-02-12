using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogSpace.BlogApi.Startup))]
namespace BlogSpace.BlogApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
