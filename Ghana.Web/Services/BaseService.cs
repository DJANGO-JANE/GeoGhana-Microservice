using Ghana.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ghana.Web.Services
{
    public class BaseService : IBaseService
    {
        public IHttpClientFactory _httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this._httpClient = httpClient;
        }
        public void Dispose()
        {
        }

        public async Task<T> SendRequestAsync<T>(ApiRequest request)
        {
            try
            {
                var client = _httpClient.CreateClient("GhanaAdministrativeDivisions");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(request.Url);
                client.DefaultRequestHeaders.Clear();

                if(request.Data != null)
                {
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(request.Data),
                        Encoding.UTF8,
                        "application/json");
                }

                HttpResponseMessage response = null;
                switch (request.ApiRequestType)
                {
                    case SD.RequestType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case SD.RequestType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.RequestType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case SD.RequestType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.RequestType.PATCH:
                        message.Method = HttpMethod.Patch;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                response = await client.SendAsync(message);
                var apiContent = await response.Content.ReadAsStringAsync();

                  var responseDTO = JsonConvert.DeserializeObject<T>(apiContent);
                return responseDTO;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
