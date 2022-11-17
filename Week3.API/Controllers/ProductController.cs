using Microsoft.AspNetCore.Mvc;
using Week3.Domain.Entities;
using Week3.Services.Abstract;

namespace Week3.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add(Product entity)
        {
         var product =   _productService.Add(entity);
            return Ok(product);
        }
        [HttpPut]
        public IActionResult Update(Product entity)
        {
          var product =  _productService.Update(entity);
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            return Ok(result);
        }
    }
}
