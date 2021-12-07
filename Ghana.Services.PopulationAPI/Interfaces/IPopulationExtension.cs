using Ghana.Services.PopulationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Interfaces
{
    public interface IPopulationExtension
    {
        abstract Population Population { get; set; }

    }
}
