using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Web.Services
{
    /// <summary>
    /// Provides an interface, pun intended, for interaction with 
    /// sections of the DivisionsAPI
    /// </summary>
    public interface IDivisionsService : IBaseService 
    {
        Task<IEnumerable<T>> GetAllSubDivisions<T>();
        Task<IEnumerable<T>> GetAllDivisionMembers<T>();
        Task<IEnumerable<T>> QueryDivisionName<T>(object name);
        //Task<T> SearchForDivisionByCode<T>(int code);
        Task<T> AddDivisionInfo<T>(T division);
        Task<T> UpdateDivisionInfo<T>(object code, T division);
        Task<T> DeleteDivisionInfo<T>(object code);
        //Task<T> FindDuplicate<T>(string name, string? divisionName);

    }
}
