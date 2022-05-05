using Core.Infrastructure.Bus;
using Ghana.Services.DivisionsAPI.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.Application.Features.ReceiveRegionDataQuery
{
    public class AdditionCommandHandler : IRequestHandler<AdditionCommand, bool>
    {
        private readonly IEventBus _bus;
        public AdditionCommandHandler()
        {

        }
        public Task<bool> Handle(AdditionCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}
