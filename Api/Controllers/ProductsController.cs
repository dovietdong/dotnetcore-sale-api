using Core.Entities;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
using Core.Exceptions;
using Core.Interfaces.Infrastructure;
using Core.Interfaces.Service;


namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductRepository _productRepository;
        IProductService _productService;

        public ProductsController(IProductRepository productRepository, IProductService productService)
        {
            _productRepository = productRepository;
            _productService = productService;
        }


        /// <summary>
        /// lấy danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _productRepository.GetAll();
                //3. trả kết quả cho client
                return Ok(products);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ 09865 để được trợ giúp.",
                    data = ex.Data,
                    stackTrace = ex.StackTrace
                };
                return StatusCode(500, response);
            }
        }

        /// <summary>
        /// lây 1 sản phẩm theo id
        /// </summary>
        /// <param name="ProductId">ProductId</param>
        /// <returns></returns>
        [HttpGet("{ProductId}")]
        public IActionResult GetById(Guid ProductId)
        {
            try
            {
                var product = _productRepository.GetById(ProductId);
                return Ok(product);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ 09865 để được trợ giúp.",
                    data = ex.Data
                };
                return StatusCode(500, response);
            }

        }

        /// <summary>
        /// thêm mới 1 sản phẩm
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// 201 - thêm mới thành công
        /// </returns>
        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                var res = _productService.Insert(product);
                return StatusCode(201, res);
            }
            // trường hợp lỗi validate do client gửi lên, (phải viết trước)
            catch (SaleValidateException ex)
            {
                // tạo 1 thông báo lỗi
                var res = new
                {
                    DevMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data,
                    stackTrace = ex.StackTrace
                };
                return BadRequest(res);

            }
            // trường hợp lỗi do code backend 
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ 09865 để được trợ giúp.",
                    data = ex.Data,
                    stackTrace = ex.StackTrace
                };
                return StatusCode(500, response);
            }
            
        }

        /// <summary>
        /// sửa 1 sản phẩm
        /// </summary>
        /// <param name="product"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPut("{productCode}")]
        public IActionResult Put(Product product, Guid productCode)
        {
            try
            {
                var res = _productService.Update(product, productCode);
                return Ok(res);
            }
            // trường hợp lỗi validate do client gửi lên, (phải viết trước)
            catch (SaleValidateException ex)
            {
                // tạo 1 thông báo lỗi
                var res = new
                {
                    DevMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data
                };
                return BadRequest(res);

            }
            // trường hợp lỗi do code backend 
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ 09865 để được trợ giúp.",
                    data = ex.Data
                };
                return StatusCode(500, response);
            }
        }

        /// <summary>
        /// xóa 
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpDelete("{productCode}")]
        public IActionResult Delete(string productCode)
        {
            try
            {
                var res = _productRepository.DeleteProduct(productCode);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ 09865 để được trợ giúp.",
                    data = ex.Data
                };
                return StatusCode(500, response);
            }
        }

        public void HandleException()
        {
             
        }
    }
}
