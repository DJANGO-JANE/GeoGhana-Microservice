using System.Collections.Generic;

namespace Ghana.Services.PopulationAPI.DTOs
{
    public class CityAsChildDTO
    {
        public string Name { get; set; }
        public string CityCode { get; set; }
        public IEnumerable<LocalityAsChildDTO> Localities { get; set; }

    }
}
