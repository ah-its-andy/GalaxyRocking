using Microsoft.Extensions.DependencyInjection;

namespace GalaxyRocking.ConsoleApp
{
    public class Startup
    {
        public void ConfigureServies(IServiceCollection services)
        {
            services.AddGalaxyServices();
        }
    }
}
