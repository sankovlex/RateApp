using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rate.Services.Rates;
using Rate.Data.Core;
using Rate.Data.Core.Repository;
using AutoMapper;
using Rate.WebAPI.Mappings;
using Rate.Data.Extensions;

namespace Rate.WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Custom services
            services.AddScoped<IEfContext, EfContext>();
            services.AddDbContext<EfContext>();
            services.Add(new ServiceDescriptor(typeof(IRepository<>), typeof(StandardRepository<>), ServiceLifetime.Scoped));
            services.AddScoped<IRateService, DefaultRateService>();

            // Auto Mapper configuration
            var mapperConfiguration = new MapperConfiguration(option => {
                option.AddProfile<DomainToViewProfile>();
                option.AddProfile<ViewToDomainProfile>();
            });
            services.AddSingleton<IMapper>(serviceProvider => mapperConfiguration.CreateMapper());

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<EfContext>().Seed();
            }
        }
    }
}
