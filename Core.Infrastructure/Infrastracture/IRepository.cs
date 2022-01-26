using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Infrastracture
{
    public interface IRepository
    {
        void Add<T>(T item);
    }
}
