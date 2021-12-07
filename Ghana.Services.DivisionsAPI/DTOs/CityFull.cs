using System.Collections.Generic;

namespace Ghana.Services.DivisionsAPI.DTOs
{
    public class CityFull
    {
        public string Name { get; set; }
        public string CityCode { get; set; }
        public string RegionName { get; set; }
        public string RegionCode { get; set; }
        public IEnumerable<LocalityAsChild> Localities { get; set; }
    }
}
