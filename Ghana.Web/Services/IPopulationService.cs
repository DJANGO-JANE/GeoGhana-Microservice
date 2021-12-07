using Ghana.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Web.Services
{
    /// <summary>
    /// Provides an interface, pun intended again, for interaction with 
    /// sections of the PopulationAPI
    /// </summary>
    public interface IPopulationService : IBaseService
    {
        Task<T> GetAllPopulationInfoAsync<T>();
        Task<T> GetPopulationOfDivisionAsync<T>(string divisionCode);
        Task<T> AddPopulationInfoAsync<T>(Population population); 
    }
}
