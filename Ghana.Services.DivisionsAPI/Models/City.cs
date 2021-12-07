using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ghana.Services.DivisionsAPI.Models
{
    public class City
    {
        [Key]
        [MaxLength(2)]
        public int CityCode { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string RegionName { get; set; }

        [Required]
        public virtual Region Region { get; set; }
        public virtual ICollection<Locality> Localities { get; set; }
    }
}
