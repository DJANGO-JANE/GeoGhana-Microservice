using Core.Infrastructure.Bus;
using Ghana.Services.DivisionsAPI.Application.Features.ReceiveRegionDataQuery;
using Ghana.Services.DivisionsAPI.Application.Features.SupplyRegionData;
using Ghana.Services.DivisionsAPI.Events;
using Ghana.Services.DivisionsAPI.Interfaces;
using Ghana.Services.DivisionsAPI.Persistence;
using Ghana.Services.DivisionsAPI.Services;
using MediatR;
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ghana.Services.DivisionsAPI", Version = "v1" });
            });

            services.AddDbContext<DivisionContext>(d =>
                                d.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                var name = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                c.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name), includeControllerXmlComments: true);
            });

            //Bus
            services.AddTransient<IEventBus, RabbitMQBus>();
            services.AddScoped<IEventHandler<RegionQueryEvent>, AdditionEventHandler>();

            services.AddScoped<IRegionRepository, RegionService>();
            services.AddScoped<ICityRepository, CityService>();
            services.AddScoped<ILocalityRepository, LocalityService>();
            services.AddMediatR(typeof(Startup));

/*            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var iLifetimeScope = sp.GetRequiredService<IRegionRepository>();

                return new RabbitMQBus(iLifetimeScope);
            });*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ghana.Services.DivisionsAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            //var repo = app.ApplicationServices.GetRequiredService<IRegionRepository>();
            eventBus.Subscribe<RegionQueryEvent,AdditionEventHandler> ();
            
        }
    }
}
