using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Application.Features
{
    public class CityQueryEvent : Event
    {
        public string DivisionCode { get; set; }

        public CityQueryEvent(string code)
        {
            DivisionCode = code;
        }
    }
}
