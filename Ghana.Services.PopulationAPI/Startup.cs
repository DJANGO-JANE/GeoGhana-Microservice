using Ghana.Services.PopulationAPI.Bus;
using Ghana.Services.PopulationAPI.CommandHandlers;
using Ghana.Services.PopulationAPI.Commands;
using Ghana.Services.PopulationAPI.Persistence;
using Ghana.Services.PopulationAPI.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Ghana.Services.PopulationAPI
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
            //Repositories
            services.AddScoped<IPopulationRepository, PopulationRepository>();

            //UI services
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ghana.Services.PopulationAPI", Version = "v1" });
            });
            services.AddSwaggerGen(c =>
            {
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
                var commentsFile = Path.Combine(baseDirectory, commentsFileName);

                //var filePath = Path.Combine(AppContext.BaseDirectory, "Ghana.Services.PopulationAPI.xml");
                c.IncludeXmlComments(commentsFile, includeControllerXmlComments: true);
            });

            //Application Dependencies
            services.AddControllers();
            services.AddDbContext<PopulationContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                        );
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            
            //Commands
            services.AddTransient<IRequestHandler<RegionAdditionCommand, bool>, AdditionCommandHandler>();

            //Bus
            services.AddTransient<IEventBus, RabbitMQBus>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ghana.Services.PopulationAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
