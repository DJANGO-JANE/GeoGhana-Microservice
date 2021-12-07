using System.ComponentModel.DataAnnotations;

namespace Ghana.Services.DivisionsAPI.DTOs
{
    public class LocalityAdd
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string CityName { get; set; }

        [Required]
        [MaxLength(30)]
        public string RegionName { get; set; }
        [Required]
        [MaxLength(2)]
        public string LocalityCode { get; set; }
    }
}
