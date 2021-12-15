using Ghana.Services.PopulationAPI.Bus;
using Ghana.Services.PopulationAPI.Commands;
using Ghana.Services.PopulationAPI.Events;
using Ghana.Services.PopulationAPI.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.CommandHandlers
{
    public class AdditionCommandHandler : IRequestHandler<RegionAdditionCommand, bool>
    {
        private readonly IEventBus _bus;
        private readonly IPopulationRepository _populationRepository;
        public AdditionCommandHandler(IEventBus bus, IPopulationRepository repository)
        {
            _bus = bus;
            _populationRepository = repository;
        }
        public Task<bool> Handle(RegionAdditionCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new AdditionMadeEvent(request.DivisionCode));
            return Task.FromResult(true);
        }
    }
}
