using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.DTOs
{
    public class LocalityViewDTO
    {
        public string Name { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string RegionCode { get; set; }
        public string CityCode { get; set; }
        public string LocalityCode { get; set; }
        public string PostCode => $"{RegionCode} {CityCode}{LocalityCode}".ToString();

    }
}
