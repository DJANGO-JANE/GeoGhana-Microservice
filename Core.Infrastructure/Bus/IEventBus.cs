
using Core.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infrastructure.Bus
{
    public interface IEventBus
    {

        /// <summary>
        /// Send commands on the bus.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="Command"/></typeparam>
        /// <param name="command">A completed task.</param>
        /// <returns></returns>
        Task SendCommand<T>(T command) where T : Command;

        /// <summary>
        /// Publish events to the bus.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="Event"/></typeparam>
        /// <param name="happenstance"></param>
        void Publish<T>(T happenstance) where T:Event;

        /// <summary>
        /// Subscribe to a published <see cref="Event"/>
        /// </summary>
        /// <typeparam name="T">Event to subscribe to.</typeparam>
        /// <typeparam name="TH">Event handler.</typeparam>
        void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>;
    }
}
