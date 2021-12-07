using Ghana.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Ghana.Web
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
/*                var config = new HttpConfiguration();
                config.Services.Replace(typeof(IAssembliesResolver), new CustomAssembliesResolver());
            config.Routes.MapHttpRoute(
                                        name: "DefaultApi",
                                        routeTemplate: "api/{controller}/{action}/{id}",
                                        defaults: new 
                                        {
                                            controller = "Regions", 
                                            action = "Get",
                                            id = RouteParameter.Optional 
                                        }
                                    );*/

            services.AddHttpClient<IPopulationService, PopulationService>();
            services.AddHttpClient<IDivisionsService, DivisionsService>();
            SD.PopulationAPIBase = Configuration["ServiceUrls:PopulationAPI"];
            SD.PopulationAPIController = Configuration["ServiceControllers:PopulationAPI"];

            SD.DivisionAPIBase = Configuration["ServiceUrls:DivisionsAPI"];
            SD.DivisionAPIController = Configuration["ServiceControllers:DivisionsAPI"];

            services.AddScoped<IPopulationService, PopulationService>();
            services.AddScoped<IDivisionsService, DivisionsService>();
            services.AddControllersWithViews();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
