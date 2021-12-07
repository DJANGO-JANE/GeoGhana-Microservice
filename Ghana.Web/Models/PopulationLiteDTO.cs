using System.Collections.Generic;

namespace Ghana.Web.Models
{
    public class PopulationLiteDTO
    {
        public string DivisionCode { get; set; }
        public int Total { get; set; }

        public object Location { get; set; }
    }
}
