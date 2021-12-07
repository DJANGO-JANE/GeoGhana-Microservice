using Ghana.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ghana.Web.Services
{
    public class PopulationService : BaseService, IPopulationService
    {
        public IHttpClientFactory _client;
        public PopulationService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _client = httpClient;
        }

        public async Task<T> AddPopulationInfoAsync<T>(Population population)
        {
            return await this.SendRequestAsync<T>(new ApiRequest()
                                {
                                    ApiRequestType = SD.RequestType.POST,
                                    Url = $"{SD.PopulationAPIBase}/{SD.PopulationAPIController}/AddData",
                                    Data = population,
                                    AccessToken = ""
                                });
        }

        public async Task<T> GetAllPopulationInfoAsync<T>()
        {
            var results = await SendRequestAsync<T>(new ApiRequest()
                                {
                                    ApiRequestType = SD.RequestType.GET,




                                    Url = $"{SD.PopulationAPIBase}/{SD.PopulationAPIController}",
                //Url = $"{SD.DivisionAPIBase}/{SD.DivisionAPIController}",

                AccessToken = ""
                                });

            return results;
        }

        public async Task<T> GetPopulationOfDivisionAsync<T>(string divisionCode)
        {
            return await this.SendRequestAsync<T>(new ApiRequest()
                                {
                                    ApiRequestType = SD.RequestType.GET,
                                    Url = $"{SD.PopulationAPIBase}/{SD.PopulationAPIController}/{divisionCode}",
                                    AccessToken = ""
                                });
        }
    }
}
