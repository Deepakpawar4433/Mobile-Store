using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mobile_StoreAPI.Controllers
{
    public class ProductController : BaseAPIController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> getAllProduct()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                return Ok(_productService.getAllProduct());
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }
        [HttpGet]
        public ActionResult<Product> getProductById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var data = _productService.GetProductById(id);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                return Ok(_productService.AddProduct(product));
            }
            return BadRequest();
        }

        [HttpPatch]
        public IActionResult updateProduct(Product product)
        {
            _productService.updateProduct(product);
            return Ok();    
        }
        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _productService.DeleteProduct(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
