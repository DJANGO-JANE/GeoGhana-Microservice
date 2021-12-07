﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ghana.Services.DivisionsAPI.Models
{
    public class Region
    {
        [Key]
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
    }
}
