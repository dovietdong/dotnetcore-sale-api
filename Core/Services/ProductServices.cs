using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Infrastructure;
using Core.Interfaces.Service;

namespace Core.Services
{
    public class ProductServices : BaseService<Product>, IProductService
    {
        public ProductServices(IProductRepository productRepository):base(productRepository)
        {

        }

        //public int Insert(Product entity)
        //{
        //    // validate

        //    return _productRepository.Insert(entity);
        //}

        //public int Update(Product entity, Guid id)
        //{
        //    //validate

        //    return (_productRepository.Update(entity, id));
        //}

        //public int InsertProduct(Product product)
        //{
        //    // mã sản phẩm không được phép để trống
        //    if (string.IsNullOrEmpty(product.ProductCode))
        //    {
        //        throw new SaleValidateException("Mã sản phẩm không được phép để trống");
        //    }

        //    var isDuplicate = _productRepository.CheckDuplidateCode(product.ProductCode);
        //    if (isDuplicate)
        //    {
        //        throw new SaleValidateException("Mã sản phẩm đã bị trùng, vui lòng kiểm tra lại.");
        //    }

        //    return _productRepository.InsertProduct(product);
        //}



        //public int UpdateProduct(Product product, string productCode)
        //{
        //    if (string.IsNullOrEmpty(product.ProductName))
        //    {
        //        throw new SaleValidateException("Tên sản phẩm không được phép để trống.");
        //    }
        //    if (product.ProductPrice == null)
        //    {
        //        throw new SaleValidateException("Giá sản phẩm không được phép để trống.");
        //    }
        //    return _productRepository.UpdateProduct(product, productCode);
        //}
    }
}
