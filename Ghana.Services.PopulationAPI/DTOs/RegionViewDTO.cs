using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.DTOs
{
    public class RegionViewDTO
    {
        public string Name { get; set; }
        public string RegionCode { get; set; }
        public string CapitalCity { get; set; }
        public int NumberOfCities { get; set; }
        public int NumberOfLocalities { get; set; }
    }

}
