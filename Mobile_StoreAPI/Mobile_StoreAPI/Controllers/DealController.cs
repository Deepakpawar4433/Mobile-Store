using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mobile_StoreAPI.Controllers
{
    public class DealController : BaseAPIController
    {
        private readonly IDealService _dealService;
        public DealController(IDealService dealService)
        {
            _dealService = dealService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Deals>> getAllDeals()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                return Ok(_dealService.GetAllDeals());
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }
        [HttpPost]
        public ActionResult AddDeal(Deals deal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _dealService.AddDeal(deal);
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult<Deals> getDealsById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var data = _dealService.getDealById(id);
            return Ok(data);
        }
        [HttpPatch]
        public IActionResult updateDeal(Deals deal)
        {
            _dealService.updateDeal(deal);
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteDeal(int id)
        {
            if(id == null)
            {
                return BadRequest();    
            }
            if (ModelState.IsValid)
            {
                _dealService.deleteDeal(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
