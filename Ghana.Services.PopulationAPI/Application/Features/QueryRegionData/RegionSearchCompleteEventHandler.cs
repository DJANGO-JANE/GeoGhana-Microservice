using Core.Infrastructure.Bus;
using Ghana.Services.PopulationAPI.Events;
using Ghana.Services.PopulationAPI.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Application.Features
{
    public class RegionSearchCompleteEventHandler //: IEventHandler<SearchCompleted>
    {

        public RegionSearchCompleteEventHandler()
        {

        }

        public Task Handle(SearchCompleted happensatance)
        {
            throw new NotImplementedException();
        }
    }
}
