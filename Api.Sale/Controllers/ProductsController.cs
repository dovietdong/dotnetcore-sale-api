using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;
using Api.Sale.Model;

namespace Api.Sale.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region
        /// <summary>
        /// lấy danh sách tất cả sản phẩm
        /// </summary>
        /// <returns>
        /// 200 - lấy thành công
        /// 204 - không có danh sách
        /// </returns>
        /// dovietdong
        [HttpGet]
        public IActionResult getAllProduct()
        {
            try
            {
                //1 khai báo thông tin database
                var connectionString = "server=127.0.0.1;uid=root;pwd=1234;database=database-ban-hang";

                //1.1 khởi tạo kết nối với mysql
                var sqlConnection = new MySqlConnection(connectionString);

                //2. lấy dữ liệu
                //2.1 khai báo câu lệnh SQL lấy dữ liệu
                var sqlCommand = "SELECT * FROM product";
                //lưu ý: nếu có tham số truyền vào câu lệnh sql thì phải sử dụng DynamicParameter

                //2.2 thực hiện lấy dữ liệu
                var products = sqlConnection.Query<Products>(sql: sqlCommand);
                //3. trả kết quả cho client
                return Ok(products);
            }
            catch (Exception ex)
            {
                return handleException(ex);
            }
        }

        #endregion

        #region
        /// <summary>
        /// lấy danh một sản phẩm
        /// </summary>
        /// <returns>
        /// 200 - lấy thành công
        /// 204 - không lấy đc
        /// </returns>
        /// dovietdong
        [HttpGet("{productId}")]
        public IActionResult getProduct(Guid productId)
        {
            try
            {
                //1 khai báo thông tin database
                var connectionString = "Server=localhost;Database=database-ban-hang;Uid=root;Pwd=1234;Allow User Variables=true";

                //1.1 khởi tạo kết nối với mysql
                var sqlConnection = new MySqlConnection(connectionString);

                //2. lấy dữ liệu
                //2.1 khai báo câu lệnh SQL lấy dữ liệu
                var sqlCommand = "SELECT * FROM product p WHERE p.ProductId = @ProductId";
                //lưu ý: nếu có tham số truyền vào câu lệnh sql thì phải sử dụng DynamicParameter
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ProductId", productId);
                //2.2 thực hiện lấy dữ liệu
                var product = sqlConnection.QueryFirstOrDefault<Products>(sql: sqlCommand, param: parameter);

                //3. trả kết quả cho client
                return Ok(product);
            }
            catch (Exception ex)
            {
                return handleException(ex);
            }
        }
        #endregion

        #region
        /// <summary>
        /// thêm mới sản phẩm vào database
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// 201 - thêm mới thành công
        /// 400 - dữ liệu không hợp lệ
        /// 500 - lỗi code
        /// </returns>
        [HttpPost]
        public IActionResult addNewProduct(Products product)
        {
            try
            {
                // khai báo các thông tin cần thiết
                var errorData = new Dictionary<string, string>();
                ErrorService error = new ErrorService();

                // bước 1: validate data
                //1.1 mã sản phẩm không được phép để trống
                if (string.IsNullOrEmpty(product.ProductCode))
                {
                    errorData.Add("ProductCode", Resource.ResourceVN.Validate_ProductCodeNotEmpty);
                }

                //1.2 tên sản phẩm không được phép để trống
                if (string.IsNullOrEmpty(product.ProductName))
                {
                    errorData.Add("ProductName", Resource.ResourceVN.Validate_ProductNameNotEmpty);
                }

                //1.3 giá sản phẩm không được phép để trống
                if (string.IsNullOrEmpty(product.ProductPrice.ToString()))
                {
                    errorData.Add("ProductPrice", Resource.ResourceVN.Validate_ProductPriceNotEmpty);
                }

                if (errorData.Count > 0)
                {
                    error.UserMsg = Resource.ResourceVN.Validate_Exception;
                    error.Data = errorData;
                    return BadRequest(error); // mã 404
                }

                //bước 2: kết nối database
                var connectionString = "Server=localhost;Database=database-ban-hang;Uid=root;Pwd=1234;Allow User Variables=true";
                var conection = new MySqlConnection(connectionString);

                var sqlCommand = "Proc_InsertProduct";

                var dynamicParams = new DynamicParameters();
                dynamicParams.Add("@m_ProductId", Guid.NewGuid());
                dynamicParams.Add("@m_ProductCode", product.ProductCode);
                dynamicParams.Add("@m_ProductName", product.ProductName);
                dynamicParams.Add("@m_ProductPrice", product.ProductPrice);
                dynamicParams.Add("@m_CreatedAt", product.CreatedAt);
                dynamicParams.Add("@m_CreatedBy", product.CreatedBy);
                dynamicParams.Add("@m_CategoryId", product.CategoryId);


                // bước 4: trả về kết quả cho client
                var res = conection.Execute(sql: sqlCommand, param: dynamicParams, commandType: System.Data.CommandType.StoredProcedure);
                return StatusCode(201, res);

            }
            catch (Exception ex)
            {
                return handleException(ex);
            }
        }
        #endregion

        #region
        [HttpDelete("{ProductId}")]
        int Delete(Guid ProductId)
        {
            return 1;
        }
        #endregion

        private IActionResult handleException(Exception ex)
        {
            ErrorService error = new ErrorService();
            error.DevMsg = ex.StackTrace;
            error.UserMsg = Resource.ResourceVN.Error_Exception;
            return StatusCode(500, error);
        }
    }
}
