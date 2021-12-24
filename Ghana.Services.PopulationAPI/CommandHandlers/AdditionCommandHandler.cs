using Core.Infrastructure.Bus;
using Ghana.Services.PopulationAPI.Application.Features;
using Ghana.Services.PopulationAPI.Commands;
using Ghana.Services.PopulationAPI.Events;
using Ghana.Services.PopulationAPI.Repository;
using log4net;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.CommandHandlers
{
    public class AdditionCommandHandler : IRequestHandler<AdditionCommand, bool>
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IEventBus _bus;
        private readonly IPopulationRepository _populationRepository;
        public AdditionCommandHandler(IEventBus bus, IPopulationRepository repository)
        {
            _bus = bus;
            _populationRepository = repository;
        }
        public Task<bool> Handle(RegionAdditionCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }


        public Task<bool> Handle(AdditionCommand request, CancellationToken cancellationToken)
        {
            var commandName = request.GetType().Name;

            if(commandName == "RegionAdditionCommand")
            {
                _bus.Publish(new RegionQueryEvent(request.DivisionCode));

            }
            else if (commandName == "LocalityAdditionCommand")
            {
                _bus.Publish(new LocalityQueryEvent(request.DivisionCode));

            }
            else
            {
                _bus.Publish(new CityQueryEvent(request.DivisionCode));
            }

            return Task.FromResult(true);
        }
    }
}
