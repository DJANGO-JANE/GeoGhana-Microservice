using Core.Infrastructure.Bus;
using Ghana.Services.DivisionsAPI.Commands;
using Ghana.Services.DivisionsAPI.Events;
using Ghana.Services.DivisionsAPI.Interfaces;
using Ghana.Services.DivisionsAPI.Models;
using Ghana.Services.DivisionsAPI.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.Application.Features.ReceiveRegionDataQuery
{
    public class AdditionEventHandler : IEventHandler<RegionQueryEvent>
    {
        public AdditionEventHandler()
        {

        }

        public Task Handle(RegionQueryEvent happensatance)
        {
            return Task.FromResult(true);
        }
    }
}
