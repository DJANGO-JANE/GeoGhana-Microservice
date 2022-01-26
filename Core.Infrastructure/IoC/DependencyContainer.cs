using Core.Infrastructure.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //services.AddScoped<IEventHandler<RegionQueryEvent>, AdditionEventHandler>();
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}
