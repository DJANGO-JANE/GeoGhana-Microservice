using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.DTOs
{
    public class PopulationAddDTO
    {
        public string DivisionCode { get; set; }
        public int Total { get; set; }

        public int? Citizens { get; set; }

        public int? Male { get; set; }

        public int? Female { get; set; }

        public int? ElderlyMale { get; set; }

        public int? ElderlyFemale { get; set; }
    }
}
