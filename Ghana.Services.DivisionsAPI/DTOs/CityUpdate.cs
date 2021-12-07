using System.ComponentModel.DataAnnotations;

namespace Ghana.Services.DivisionsAPI.DTOs
{
    public class CityUpdate
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string CityCode { get; set; }
        [Required]
        [MaxLength(30)]
        public string RegionName { get; set; }
        public string RegionCode { get; set; }
    }
}
