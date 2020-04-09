using GildedRoseCodeChallenge.Services;
using GildedRoseCodeChallenge.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GildedRoseCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create service collection and configure our services
            var services = ConfigureServices();

            // Generate a provider
            var serviceProvider = services.BuildServiceProvider();

            // Kick off our actual code
            serviceProvider.GetService<Application>().Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IInventoryService, InventoryService>();
            services.AddSingleton<IQualityCalculator, QualityCalculator>();
            services.AddTransient<Application>();

            return services;
        }
    }
}
