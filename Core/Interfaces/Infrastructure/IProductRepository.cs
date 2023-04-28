using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Infrastructure
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        /// <summary>
        /// thêm mới sản phẩm
        /// </summary>
        /// <param name="product">số bản ghi thêm mới được</param>
        /// <returns></returns>
        int InsertProduct(Product product);

        /// <summary>
        /// sửa sản phẩm
        /// </summary>
        /// <param name="product"></param>
        /// <param name="ProductId"></param>
        /// <returns>số sản phẩm đã được sửa</returns>
        int UpdateProduct(Product product, string productCode);

        /// <summary>
        /// xoa 1 ban ghi
        /// </summary>
        /// <param name="productCode">ma san pham</param>
        /// <returns></returns>
        int DeleteProduct(string productCode);

        /// <summary>
        /// phân trang
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageOffset"></param>
        /// <param name="PageCount"></param>
        /// <returns>danh sách sản phẩm cho mỗi trang</returns>
        IEnumerable<Product> GetPagging(int PageSize, int PageOffset, int PageCount);

        bool CheckDuplidateCode(string ProductCode);
    }
}
