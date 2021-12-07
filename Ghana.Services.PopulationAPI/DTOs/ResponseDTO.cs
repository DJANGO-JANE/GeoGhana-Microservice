using System.Collections.Generic;

namespace Ghana.Services.PopulationAPI.DTOs
{
    public class ResponseDTO
    {
        public bool IsSuccessful { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
