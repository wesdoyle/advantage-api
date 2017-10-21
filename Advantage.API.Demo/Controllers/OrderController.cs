using Advantage.API.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Advantage.API.Demo.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly ApiContext _ctx;

        public OrderController(ApiContext ctx)
        {
            _ctx = ctx;
        }

        // GET api/values
        [HttpGet]
        public PaginatedResponse<Order> Get(int pageIndex, int pageSize)
        {
            var data = _ctx.Orders;
            return new PaginatedResponse<Order>(data, pageIndex, pageSize);
        }

        // GET api/values/5
        [HttpGet("{id}", Name ="GetOrder")]
        public Order Get(int id)
        {
            return _ctx.Orders.Find(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            _ctx.Orders.Add(order);
            _ctx.SaveChanges();

            return CreatedAtRoute("GetOrder", new { id = order.Id }, order);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order order)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}