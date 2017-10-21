using Advantage.API.Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Advantage.API.Demo.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly ApiContext _ctx;

        public OrderController(ApiContext ctx)
        {
            _ctx = ctx;

            if (_ctx.Orders.Count() == 0)
            {
                DataSeed.SeedSampleOrders(_ctx);
            }
        }
    }
}