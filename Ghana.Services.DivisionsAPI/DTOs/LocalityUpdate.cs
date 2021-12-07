using System.ComponentModel.DataAnnotations;

namespace Ghana.Services.DivisionsAPI.DTOs
{
    public class LocalityUpdate
    {

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string CityName { get; set; }
        [MaxLength(30)]
        public string RegionName { get; set; }
    }
}
