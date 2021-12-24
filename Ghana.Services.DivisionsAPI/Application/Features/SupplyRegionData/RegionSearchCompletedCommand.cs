using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.Commands
{
    public class RegionSearchCompletedCommand :SearchCommand
    {
        public object Region { get; set; }
        public RegionSearchCompletedCommand(object region)
        {
            Region = region;
        }
    }
}
