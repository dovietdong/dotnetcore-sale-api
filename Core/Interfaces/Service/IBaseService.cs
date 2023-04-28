using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Service
{
    public interface IBaseService<T>
    {
        int Insert(T entity);
        int Update(T entity, Guid id);
    }
}
