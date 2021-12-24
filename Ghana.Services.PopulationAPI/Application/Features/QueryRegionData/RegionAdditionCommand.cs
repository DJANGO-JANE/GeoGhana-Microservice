using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ghana.Services.PopulationAPI.Commands;
using Ghana.Services.PopulationAPI.DTOs;

namespace Ghana.Services.PopulationAPI.Application.Features
{
    public class RegionAdditionCommand : AdditionCommand
    {
        public RegionAdditionCommand(string regionCode)
        {
            DivisionCode = regionCode;
        }
    }
}
