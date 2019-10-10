using BooksLib;
using BooksLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace BooksSample
{
    public class AppServices
    {
        private AppServices()
        {
            Container = RegisterServices();
        }

        private static AppServices _instance;
        public static AppServices Instance => _instance ?? (_instance = new AppServices());

        public IServiceProvider Container { get; }

        private IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddLogging(config =>
            {
                config.AddFilter("BooksLib.SampleBooksService", LogLevel.Trace);
//                config.AddFilter(level => level >= LogLevel.Trace);
                config.AddConsole();
                config.AddDebug();
            });
#if API
            services.AddTransient<IBooksService, APIBooksService>();
#else
            services.AddTransient<IBooksService, SampleBooksService>();
#endif
            services.AddTransient<MainPageViewModel>();
            return services.BuildServiceProvider();
        }
    }
}
