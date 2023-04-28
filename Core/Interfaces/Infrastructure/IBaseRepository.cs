using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Infrastructure
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// lấy tất cả cột có trong bảng
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        IEnumerable<T> GetById(Guid id);

        /// <summary>
        /// thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Insert(T entity);
        int Update(T entity, Guid id);
        int Delete(Guid id);
    }
}
