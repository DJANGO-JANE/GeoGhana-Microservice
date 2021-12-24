using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infrastructure.Bus
{
    public interface IEventHandler<in TEvent> :IEventHandler where TEvent: Event
    {
        Task Handle(TEvent happensatance);
    }
    public interface IEventHandler
    {

    }
}
