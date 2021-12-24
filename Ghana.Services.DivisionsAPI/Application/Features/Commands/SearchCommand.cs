using Core.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.Commands
{
    public class SearchCommand : Command
    {
        public object Data { get; set; }
    }
}
