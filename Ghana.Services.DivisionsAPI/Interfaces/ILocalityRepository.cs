using Ghana.Services.DivisionsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghana.Services.DivisionsAPI.Interfaces
{
    public interface ILocalityRepository
    {
        bool SaveChanges();
        IEnumerable<Locality> GetAllLocalities();
        Task<Locality> SearchLocalityByName(string name);
        Task<IEnumerable<Locality>> QueryLocalityName(string name);
        void AddNewLocality(Locality locality);
        void UpdateLocality(Locality locality);
        void DeleteLocality(Locality locality);
        Task<Locality> SearchPostCode(string postcode);
    }
}
