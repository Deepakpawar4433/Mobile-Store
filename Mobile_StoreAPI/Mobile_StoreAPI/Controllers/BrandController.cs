using Azure;
using Microsoft.AspNetCore.Mvc;
namespace Mobile_StoreAPI.Controllers
{
    public class BrandController : BaseAPIController
    {
        private readonly IBrandService _brandServices;
        public BrandController(IBrandService brandServices)
        {
            _brandServices = brandServices;
        }
        [HttpPost]
        public IActionResult AddBrand(Brand brand)
        {
            if (brand == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _brandServices.CreateBrand(brand);
                return Ok();
            }
            return BadRequest();

        }
        [HttpGet]
        public ActionResult<IEnumerable<Brand>> GetAllBrands()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                return Ok(_brandServices.GetAllBrands());
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }
        [HttpDelete]
        public IActionResult DeleteBrand(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _brandServices.DeleteBrand(id);
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult<Brand> GetBrandById(int id)
        {
            if (!ModelState.IsValid){
                return BadRequest();    
            }
            var data = _brandServices.GetBrandById(id);
            return Ok(data);
        }

        [HttpPatch]
        public IActionResult UpdateBrand(Brand brand)
        {
            _brandServices.UpdateBrand(brand);
            return Ok();
        }

    }
}
