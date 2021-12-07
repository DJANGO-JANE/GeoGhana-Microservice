using Ghana.Services.PopulationAPI.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ghana.Services.PopulationAPI.Models
{
    public class Region :IPopulationExtension
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(3)]
        public string RegionCode { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string CapitalCity { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Locality> Localities { get; set; }
        public virtual Population Population { get; set; }
    }

}