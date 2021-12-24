using Ghana.Services.DivisionsAPI.Commands;
using log4net;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.CommandHandlers
{
    public class SearchCommandHandler : IRequestHandler<SearchCommand, bool>
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Task<bool> Handle(SearchCommand request, CancellationToken cancellationToken)
        {
            log.Info($"Search command {request}");
            throw new NotImplementedException();
        }
    }
}
