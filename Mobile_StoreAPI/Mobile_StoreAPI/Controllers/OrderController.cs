using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_StoreAPI.Services.OrderService.IOrderService;
using System;

namespace Mobile_StoreAPI.Controllers
{
    public class OrderController : BaseAPIController
    {
        private readonly IOrderService _orderService;
        public OrderController (IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Orders>> getAllOrder()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return NotFound();
                }
                return Ok(_orderService.getAllOrder());
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }
        [HttpGet]
        public ActionResult<Orders> getOrderById(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var data = _orderService.GetOrderById(id);
            return Ok(data);
        }
        [HttpPut]
        public IActionResult AddOrder(Orders order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                return Ok(_orderService.AddOrder(order));
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteOrder(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                return Ok(_orderService.DeleteOrder(id));
            }
            return BadRequest();
        }
        [HttpPatch]
        public IActionResult UpdateOrder(Orders order)
        {
            _orderService.UpdateOrder(order);
            return Ok();
        }
    }
}
