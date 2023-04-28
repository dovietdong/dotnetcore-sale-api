using Core.Exceptions;
using Core.Interfaces.Infrastructure;
using Core.Interfaces.Service;
using Core.SaleAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        // xử lí DI
        IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public int Insert(T entity)
        {
            // validate chung
            ValidateData(entity);
            // validate riêng

            // thêm mới
            var res = _baseRepository.Insert(entity);
            return res;
        }

        public int Update(T entity, Guid id)
        {
            // validate chung

            // validate riêng

            // sửa
            var res = _baseRepository.Update(entity, id);
            return res;
        }

        private void ValidateData(T entity)
        {
            //lấy danh sách các property không để trống - các trường có attribute là NotEmpty
            var propsNotEmpty = entity.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(NotEmpty)));
            foreach (var prop in propsNotEmpty)
            {
                var propValue = prop.GetValue(entity);
                var propName = prop.Name;
                if(propName == null || string.IsNullOrEmpty(propValue.ToString()))
                {
                    throw new SaleValidateException(string.Format(Core.Resource.ResourceVN.EmtyValidateException, propName));
                }
            }

        }
    }
}
