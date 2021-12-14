using Ghana.Services.PopulationAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Bus
{
    public interface IEventHandler<in TEvent> :IEventHandler where TEvent: Event
    {
        Task Handle(TEvent happensatance);
    }
    public interface IEventHandler
    {

    }
}
