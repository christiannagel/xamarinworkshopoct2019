using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPIServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BooksAPIServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BooksContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("BooksConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddHttpClient("myclient").AddTypedClient<MySampleService>();
            services.AddSwaggerGen(options =>
            {
                // options.IncludeXmlComments("../docs/BooksServiceSample.xml");
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Books Service API",
                    Version = "v1",
                    Description = "Sample service for a Xamarin workshop",
                    Contact = new OpenApiContact { Name = "Christian Nagel", Url = new Uri("https://csharp.christiannagel.com") },
                    License = new OpenApiLicense { Name = "MIT License" }
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Book Services"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
