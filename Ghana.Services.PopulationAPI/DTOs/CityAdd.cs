using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ghana.Services.PopulationAPI.DTOs
{ 
    public class CityAdd
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string RegionName { get; set; }
    }
}
