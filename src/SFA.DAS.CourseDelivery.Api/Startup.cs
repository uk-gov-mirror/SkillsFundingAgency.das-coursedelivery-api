using System;
using System.IO;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SFA.DAS.Configuration.AzureTableStorage;
using SFA.DAS.CourseDelivery.Api.AppStart;
using SFA.DAS.CourseDelivery.Api.Infrastructure;
using SFA.DAS.CourseDelivery.Application.ProviderCourseImport.Handlers.ImportProviderStandards;
using SFA.DAS.CourseDelivery.Domain.Configuration;

namespace SFA.DAS.CourseDelivery.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            var config = new ConfigurationBuilder()
                .AddConfiguration(configuration)
                .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile("appsettings.Development.json", true)
#endif
                .AddEnvironmentVariables();

            if (!configuration["Environment"].Equals("DEV", StringComparison.CurrentCultureIgnoreCase))
            {
                config.AddAzureTableStorage(options =>
                    {
                        options.ConfigurationKeys = configuration["ConfigNames"].Split(",");
                        options.StorageConnectionString = configuration["ConfigurationStorageConnectionString"];
                        options.EnvironmentName = configuration["Environment"];
                        options.PreFixConfigurationKeys = false;
                    }
                );
            }
            
            _configuration = config.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<CourseDirectoryConfiguration>(_configuration.GetSection("CourseDirectoryConfiguration"));
            services.AddSingleton(cfg => cfg.GetService<IOptions<CourseDirectoryConfiguration>>().Value);
            services.Configure<CourseDeliveryConfiguration>(_configuration.GetSection("CourseDeliveryConfiguration"));
            services.AddSingleton(cfg => cfg.GetService<IOptions<CourseDirectoryConfiguration>>().Value);
            services.Configure<AzureActiveDirectoryConfiguration>(_configuration.GetSection("AzureAd"));
            services.AddSingleton(cfg => cfg.GetService<IOptions<AzureActiveDirectoryConfiguration>>().Value);

            var coursesConfiguration = _configuration
                .GetSection("CourseDeliveryConfiguration")
                .Get<CourseDeliveryConfiguration>();

            if (!ConfigurationIsLocalOrDev())
            {
                var azureAdConfiguration = _configuration
                    .GetSection("AzureAd")
                    .Get<AzureActiveDirectoryConfiguration>();

                services.AddAuthentication(azureAdConfiguration);
            }

            if (_configuration["Environment"] != "DEV")
            {
                services.AddHealthChecks();
            }

            services.AddMediatR(typeof(ImportDataCommand).Assembly);

            services.AddServiceRegistration(_configuration["Environment"] == "DEV");

            services.AddDatabaseRegistration(coursesConfiguration, _configuration["Environment"]);

            services
                .AddMvc(o =>
                {
                    if (!ConfigurationIsLocalOrDev())
                    {
                        o.Conventions.Add(new AuthorizeControllerModelConvention());
                    }
                    o.Conventions.Add(new ApiExplorerGroupPerVersionConvention());
                }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddApplicationInsightsTelemetry(_configuration["APPINSIGHTS_INSTRUMENTATIONKEY"]);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CourseDeliveryAPI", Version = "v1" });
                c.SwaggerDoc("operations", new OpenApiInfo { Title = "CoursesAPI operations" });
                c.OperationFilter<SwaggerVersionHeaderFilter>();
            });
            services.AddApiVersioning(opt => {
                opt.ApiVersionReader = new HeaderApiVersionReader("X-Version");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CourseDeliveryAPI");
                c.SwaggerEndpoint("/swagger/operations/swagger.json", "Operations v1");
                c.RoutePrefix = string.Empty;
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseAuthentication();
            
            if (_configuration["Environment"] != "DEV")
            {
                app.UseHealthChecks();
            }

            app.UseRouting();
            app.UseEndpoints(builder =>
            {
                builder.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller=Providers}/{action=Index}/{id?}");
            });

            
        }
        
        private bool ConfigurationIsLocalOrDev()
        {
            return _configuration["Environment"].Equals("LOCAL", StringComparison.CurrentCultureIgnoreCase) ||
                   _configuration["Environment"].Equals("DEV", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}