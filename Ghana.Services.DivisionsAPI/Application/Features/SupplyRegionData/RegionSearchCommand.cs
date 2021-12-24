using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.Commands
{
    public class RegionSearchCommand : SearchCommand
    {
        public RegionSearchCommand(object data)
        {
            Data = data;
        }
    }
}
