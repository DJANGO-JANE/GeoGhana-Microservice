using Ghana.Services.PopulationAPI.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ghana.Services.PopulationAPI.Models
{
    public class City : IPopulationExtension
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None),MaxLength(2)]
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
        public virtual Population Population { get; set; }

    }
}
