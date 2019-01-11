using Microsoft.Extensions.DependencyInjection;

namespace GalaxyRocking.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            var startup = new Startup();
            startup.ConfigureServies(services);
            var serviceProvider = services.BuildServiceProvider();
            using(var scope = serviceProvider.CreateScope())
            {
                var hosting = new Hosting(scope.ServiceProvider);
                hosting.Run(args);
            }
        }
    }
}
