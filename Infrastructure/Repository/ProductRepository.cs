using Core.Entities;
using Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using Core.Exceptions;

namespace Infrastructure.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        /// <summary>
        /// kiểm tra trùng mã sản phẩm
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public bool CheckDuplidateCode(string productCode)
        {
            //1.1 khởi tạo kết nối với mysql
            using (_connection = new MySqlConnection(connectionString))
            {

                //2. lấy dữ liệu
                //2.1 khai báo câu lệnh SQL lấy dữ liệu
                var sqlCheck = "SELECT ProductCode FROM product  WHERE ProductCode = @ProductCode;";
                var isDuplicateCode = _connection.QueryFirstOrDefault<string>(sqlCheck, param: new { ProductCode = productCode });
                if (isDuplicateCode != null)
                {
                    return true;
                }

                return false;
            }

        }

        public int DeleteProduct(string productCode)
        {
            using (_connection = new MySqlConnection(connectionString))
            {
                //var dynamicParams = new DynamicParameters();
                //dynamicParams.Add("@productCode", productCode);
                var sqlCommand = $"DELETE FROM product WHERE ProductCode = '{productCode}';";
                // bước 4: trả về kết quả cho client
                var res = _connection.Execute(sql: sqlCommand);
                return res;
            }

        }


        public IEnumerable<Product> GetPagging(int PageSize, int PageOffset, int PageCount)
        {
            throw new NotImplementedException();
        }

        public int InsertProduct(Product product)
        {
            using (_connection = new MySqlConnection(connectionString))
            {

                var sqlCommand = "Proc_InsertProduct";

                var dynamicParams = new DynamicParameters();
                dynamicParams.Add("@m_ProductId", Guid.NewGuid());
                dynamicParams.Add("@m_ProductCode", product.ProductCode);
                dynamicParams.Add("@m_ProductName", product.ProductName);
                dynamicParams.Add("@m_ProductPrice", product.ProductPrice);
                dynamicParams.Add("@m_CreatedAt", product.CreatedAt);
                dynamicParams.Add("@m_CreatedBy", product.CreatedBy);
                dynamicParams.Add("@m_CategoryId", product.CategoryId);


                // trả về kết quả cho client
                var res = _connection.Execute(sql: sqlCommand, param: dynamicParams, commandType: System.Data.CommandType.StoredProcedure);
                return res;

            }
        }

        public int UpdateProduct(Product product, string productCode)
        {
            using (_connection = new MySqlConnection(connectionString))
            {
                var sqlCommand = "Proc_UpdateProduct";

                var dynamicParams = new DynamicParameters();
                dynamicParams.Add("@m_ProductCode", productCode);
                dynamicParams.Add("@m_ProductName", product.ProductName);
                dynamicParams.Add("@m_ProductPrice", product.ProductPrice);
                dynamicParams.Add("@m_CreatedAt", product.CreatedAt);
                dynamicParams.Add("@m_CreatedBy", product.CreatedBy);
                dynamicParams.Add("@m_CategoryId", product.CategoryId);

                var res = _connection.Execute(sql: sqlCommand, param: dynamicParams, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }

        }
    }
}
