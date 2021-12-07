using System.ComponentModel.DataAnnotations;

namespace Ghana.Services.DivisionsAPI.DTOs
{
    public class RegionUpdate
    {

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string CapitalCity { get; set; }
    }
}
