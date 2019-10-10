using Microsoft.Extensions.DependencyInjection;
using System;

namespace DISample
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = RegisterServices();

            var controller = container.GetRequiredService<HomeController>();
            var result = controller.Index("Katharina");
            Console.WriteLine(result);
        }

        public static ServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IGreetingService, GreetingService>();
            services.AddTransient<HomeController>();
            return services.BuildServiceProvider();
        }
    }
}
