using Ghana.Services.PopulationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Repository
{
    public interface IPopulationRepository
    {
        Task<List<Population>> GetThePopulation();
        Task<Population> AddPopulationData(Population population);
        Task<Population> UpdatePopulationData(Population population);

        //int SaveChanges();
        /*        Task<Region> GetRegionPopulation(string regionCode);
                Task<City> GetCityPopulation(string cityCode);
                Task<Locality> GetLocalityPopulation(string localityCode);

                Task<T> GetPopulationData(string code);
         */
    }
}
