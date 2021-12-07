using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.DTOs
{
    public class CityFullDTO
    {
        public string Name { get; set; }
        public string CityCode { get; set; }
        public string RegionName { get; set; }
        public string RegionCode { get; set; }
        public IEnumerable<LocalityAsChildDTO> Localities { get; set; }

    }
}
