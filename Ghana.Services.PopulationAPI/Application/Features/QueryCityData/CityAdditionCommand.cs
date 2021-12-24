using Ghana.Services.PopulationAPI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Application.Features
{

    public class CityAdditionCommand : AdditionCommand
    {
        public CityAdditionCommand(string cityCode)
        {
            DivisionCode = cityCode;
        }
    }
}
