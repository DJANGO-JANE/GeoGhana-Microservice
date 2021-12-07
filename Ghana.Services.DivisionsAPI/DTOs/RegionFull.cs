using System.Collections.Generic;

namespace Ghana.Services.DivisionsAPI.DTOs
{
    public class RegionFull
    {
        public string RegionCode { get; set; }
        public string Name { get; set; }
        public string CapitalCity { get; set; }
        public IEnumerable<CityAsChild> Cities { get; set; }
        //public IEnumerable<Locality> Localities { get; set; }
    }
}
