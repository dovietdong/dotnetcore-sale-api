using Core.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var res = _categoryRepository.GetAll();
                return Ok(res);
            }
            // trường hợp lỗi do code backend 
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data
                };
                return StatusCode(500, response);
            }
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetAll(Guid categoryId)
        {
            try
            {
                var res = _categoryRepository.GetById(categoryId);
                return Ok(res);
            }
            // trường hợp lỗi do code backend 
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data
                };
                return StatusCode(500, response);
            }
        }
    }
}
