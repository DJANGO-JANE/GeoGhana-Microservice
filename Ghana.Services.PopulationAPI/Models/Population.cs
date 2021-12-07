using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Models
{
    public class Population
    {
        [Key]
        public int PopulationId { get; set; }
        [Required,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string DivisionCode { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public int Citizens { get; set; }

        [Required]
        public int Male { get; set; }

        [Required]
        public int Female { get; set; }

        [Required]
        public int ElderlyMale { get; set; }

        [Required]
        public int ElderlyFemale { get; set; }

    }
}
