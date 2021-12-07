using System.Collections.Generic;

namespace Ghana.Services.DivisionsAPI.DTOs
{
    public class CityAsChild
    {
        public string Name { get; set; }
        public string CityCode { get; set; }

        public IEnumerable<LocalityAsChild> Localities { get; set; }
    }
}
