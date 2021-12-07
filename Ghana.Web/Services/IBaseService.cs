using Ghana.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghana.Web.Services
{
    public interface IBaseService:IDisposable
    {
        Task<T> SendRequestAsync<T>(ApiRequest request);
    }
}
