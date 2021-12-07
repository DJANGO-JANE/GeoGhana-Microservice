using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.DTOs
{
    public class PopulationLiteDTO
    {
        public string DivisionCode { get; set; }
        public int Total { get; set; }

        public object Location { get; set; }
    }
}
