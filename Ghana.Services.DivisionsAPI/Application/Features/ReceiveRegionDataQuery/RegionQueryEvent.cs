using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.Application.Features.ReceiveRegionDataQuery
{
    public class RegionQueryEvent : Event
    {
        public string DivisionCode { get; set; }

        public RegionQueryEvent(string code)
        {
            DivisionCode = code;
        }
    }
}
