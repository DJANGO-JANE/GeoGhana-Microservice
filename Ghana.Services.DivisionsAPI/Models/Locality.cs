using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ghana.Services.DivisionsAPI.Models
{
    public class Locality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConstID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        #region some extra code

        [Required]
        [MaxLength(30)]
        public string CityName { get; set; }

        [Required]
        [MaxLength(30)]
        public string RegionName { get; set; }

        [Required]
        [MaxLength(2)]
        public string LocalityCode { get; set; }
        public override string ToString()
        {
            return $"{Region.RegionCode} {City.CityCode}{LocalityCode}".ToString();
        }

        #endregion

        [DisplayName("RegionCode")]
        public virtual Region Region { get; set; }

        [Required]
        [DisplayName("CityCode")]
        public virtual City City { get; set; }
    }
}
