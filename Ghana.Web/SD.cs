using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Web
{
    public static class SD
    {
        public static string? PopulationAPIBase { get; set; }
        public static string? PopulationAPIController { get; set; }
        public static string? DivisionAPIBase { get; set; }
        public static string? DivisionAPIController { get; set; }
        public enum RequestType
        {
            GET,
            POST,
            PUT,
            PATCH,
            DELETE
        }
        public enum Sub
        {
            Region,
            City,
            Locality
        }
    }
}
