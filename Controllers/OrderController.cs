using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictorianPlumbing.Models;
using VictorianPlumbing.Services;

namespace VictorianPlumbing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {

        private readonly ICreateOrderService _createOrderLayer;

        public OrderController(ICreateOrderService dataLayer)
        {
            _createOrderLayer = dataLayer;
        }

        [Route("[action]")]
        [HttpPost(Name = "InsertOrder")]
        public ActionResult<string> InsertOrder([FromBody] Order order)
        {
            // If request does not contain correct data, return NotFound page.
            if(order == null)
            {
                return NotFound();
            }

            // Create order at Services level and return OrderCreated object with data to confirm transaction.
            var orderCreated = _createOrderLayer.InsertOrder(order);
            return Ok(orderCreated);
        }


    }
}
