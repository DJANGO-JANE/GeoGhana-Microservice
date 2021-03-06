using System.ComponentModel.DataAnnotations;

namespace Ghana.Services.DivisionsAPI.DTOs
{
    public class RegionAdd
    {
        [Required]
        [MaxLength(2)]
        public string RegionCode { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string CapitalCity { get; set; }
    }
}
