using static Ghana.Web.SD;

namespace Ghana.Web.Models
{
    public class ApiRequest
    {
        public RequestType ApiRequestType { get; set; } = RequestType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
