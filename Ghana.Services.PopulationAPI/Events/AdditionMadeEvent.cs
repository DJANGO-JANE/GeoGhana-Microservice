using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Events
{
    public class AdditionMadeEvent :Event
    {
        public string Division_Code { get; private set; }

        public AdditionMadeEvent(string code)
        {
            Division_Code = code;
        }
    }
}
