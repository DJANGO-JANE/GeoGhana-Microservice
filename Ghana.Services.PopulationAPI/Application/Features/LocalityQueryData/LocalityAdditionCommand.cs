using Ghana.Services.PopulationAPI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Application.Features
{
    public class LocalityAdditionCommand :AdditionCommand
    {
        public LocalityAdditionCommand(string localityCode)
        {
            DivisionCode = localityCode;
        }
    }
}
