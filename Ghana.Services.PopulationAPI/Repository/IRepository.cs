using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Services.PopulationAPI.Repository
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T item);
        Task<T> Update(string code, T item);
        Task<T> LookFor(string code);
    }
}
