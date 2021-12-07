using System.Collections.Generic;

namespace Ghana.Web.Models
{
    public class RegionFullDTO
    {
            public string RegionCode { get; set; }
            public string Name { get; set; }
            public string CapitalCity { get; set; }
            public IEnumerable<CityAsChildDTO> Cities { get; set; }

    }
}
