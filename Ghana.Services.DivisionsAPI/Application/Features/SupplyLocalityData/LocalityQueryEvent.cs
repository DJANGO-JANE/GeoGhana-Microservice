using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.Events
{
    public class LocalityQueryEvent :Event
    {
        public string DivisionCode { get; set; }

        public LocalityQueryEvent(string code)
        {
            DivisionCode = code;
        }
    }
}
