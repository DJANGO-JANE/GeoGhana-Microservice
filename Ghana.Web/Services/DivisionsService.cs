using Ghana.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static Ghana.Web.SD;

namespace Ghana.Web.Services
{
    public class DivisionsService : BaseService,IDivisionsService
    {
        public IHttpClientFactory _client;
        public DivisionsService(IHttpClientFactory client):base(client)
        {
            _client = client;
        }

        public async Task<T> AddDivisionInfo<T>(T division)
        {

            return await this.SendRequestAsync<T>(new ApiRequest()
            {
                ApiRequestType = SD.RequestType.POST,
                Url = $"{SD.DivisionAPIBase}/{SD.DivisionAPIController}/Add",
                Data = division,
                AccessToken = ""
            }); 


            /*            if (division == null)
                        {
                            throw new ArgumentNullException(nameof(division));
                        }
                        //This just works. Tamper at your own risk
                        Region region = _regionalContext.RegionsGH.Single(r => r.Name == city.RegionName);
                        City cityTemp = new City
                        {
                            Name = city.Name,
                            RegionName = city.RegionName,
                            Region = region,
                            CityCode = city.CityCode
                        };



                        //Check which type of division it is and populate the children fields
                        switch(division)
                        {
                            case Sub.City:
                                var superior = _
                        }
                        _regionalContext.CitiesGH.Add(cityTemp);*/
        }

        public async Task<T> DeleteDivisionInfo<T>(object code)
        {
            return await this.SendRequestAsync<T>(new ApiRequest()
            {
                ApiRequestType = SD.RequestType.DELETE,
                Url = $"{SD.DivisionAPIBase}/{SD.DivisionAPIController}/{code}",
                AccessToken = ""
            });
        }

        public Task<T> FindDuplicate<T>(string name, string? divisionName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllDivisionMembers<T>()
        {
            return (IEnumerable<T>)await SendRequestAsync<T>(new ApiRequest()
            {
                ApiRequestType = SD.RequestType.GET,
                Url = $"{SD.DivisionAPIBase}/{SD.DivisionAPIController}",
                AccessToken = ""
            }); 
        }

        public Task<IEnumerable<T>> GetAllSubDivisions<T>()
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<T>> QueryDivisionName<T>(object name)
        {
            return (IEnumerable<T>)await SendRequestAsync<T>(new ApiRequest()
            {
                ApiRequestType = SD.RequestType.GET,
                Url = $"{SD.DivisionAPIBase}/{SD.DivisionAPIController}/Query?name={name}",
                AccessToken = ""
            });
        }

        public async Task<T> SearchForDivisionByCode<T>(object code)
        {
            return await this.SendRequestAsync<T>(new ApiRequest()
            {
                ApiRequestType = SD.RequestType.GET,
                Url = $"{SD.DivisionAPIBase}/{SD.DivisionAPIController}/{code}",
                Data = code,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateDivisionInfo<T>(object code, T division)
        {
            return await this.SendRequestAsync<T>(new ApiRequest()
            {
                ApiRequestType = SD.RequestType.PATCH,
                Url = $"{SD.DivisionAPIBase}/{SD.DivisionAPIController}/{code}",
               Data = division,
                AccessToken = ""
            });
        }
    }
}
