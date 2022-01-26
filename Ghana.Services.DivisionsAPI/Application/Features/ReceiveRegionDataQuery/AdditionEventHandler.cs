using Core.Infrastructure.Bus;
using Ghana.Services.DivisionsAPI.Application.Features.SupplyRegionData;
using Ghana.Services.DivisionsAPI.Interfaces;
using System;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.Application.Features.ReceiveRegionDataQuery
{
    public class AdditionEventHandler : IEventHandler<RegionQueryEvent>
    {
        public readonly IRegionRepository _repository;
        public readonly IEventBus _bus;


        public AdditionEventHandler(IEventBus bus, IRegionRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _bus = bus;
        }

        public Task Handle(RegionQueryEvent happenstance)
        {
            var region = _repository.SearchRegionByCode(happenstance.DivisionCode).GetAwaiter().GetResult();
            _bus.Publish(new SearchCompleted(region));
            return Task.FromResult(true);
        }
    }
}
