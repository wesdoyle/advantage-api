using Advantage.API.Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Advantage.API.Demo.Controllers
{
    public class ServerController : Controller
    {
        private readonly ApiContext _ctx;

        public ServerController(ApiContext ctx)
        {
            _ctx = ctx;
        }

        // GET api/values
        [HttpGet]
        public PaginatedResponse<Server> Get(int pageIndex, int pageSize)
        {
            var data = _ctx.Servers;
            return new PaginatedResponse<Server>(data, pageIndex, pageSize);
        }

        // GET api/values/5
        [HttpGet("{id}", Name ="GetServer")]
        public Server Get(int id)
        {
            return _ctx.Servers.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Server server)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Server server)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
