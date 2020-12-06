using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SEODemo.Models;
using SEODemo.Services;
using Serilog;

namespace SEODemo
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
            services.AddControllers();

            //Customize DIs
            services.AddScoped<IEngineService, EngineService>();
            services.Configure<SEOSettingsModel>(Configuration.GetSection("SEOSettings"));

            //swagger
            // Register the Swagger services
            var swagSettings = Configuration.GetSection("SwaggerSettings");
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = swagSettings.GetSection("Version").Value;
                    document.Info.Title = swagSettings.GetSection("Title").Value;
                    document.Info.Description = swagSettings.GetSection("Description").Value;
                    document.Info.TermsOfService = swagSettings.GetSection("TermsOfService").Value;
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = swagSettings.GetSection("User").Value,
                        Email = swagSettings.GetSection("Email").Value,
                        Url = swagSettings.GetSection("ContactUrl").Value
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = swagSettings.GetSection("License").GetSection("Name").Value,
                        Url = swagSettings.GetSection("License").GetSection("Url").Value
                    };
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
