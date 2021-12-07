using Ghana.Services.DivisionsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.Interfaces
{
    public interface ICityRepository
    {
        bool SaveChanges();
        Task<IEnumerable<Locality>> GetAllLocalities();
        Task<IEnumerable<City>> GetAllCities();
        Task<City> SearchCityByCode(int code);
        Task<IEnumerable<City>> QueryCityName(string name);
        Task<City> FindDuplicate (string name, string? regionName);
        void AddNewCity(City city);
        void UpdateCity(City city);
        void DeleteCity(City city);
    }
}
