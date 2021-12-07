using System.Collections.Generic;

namespace Ghana.Web.Models
{
    public class CityAsChildDTO
    {
        public string Name { get; set; }
        public string CityCode { get; set; }
        public IEnumerable<LocalityAsChildDTO> Localities { get; set; }

    }
}
