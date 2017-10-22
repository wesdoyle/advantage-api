using Advantage.API.Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Advantage.API.Demo.Controllers
{
    [Route("api/[controller]")]
    public class ServerController : Controller
    {
        private readonly ApiContext _ctx;

        public ServerController(ApiContext ctx)
        {
            _ctx = ctx;
        }

        // GET api/server
        [HttpGet]
        public IActionResult Get()
        {
            var response = _ctx.Servers.ToList(); 
            return Ok(response);
        }

        // GET api/server/5
        [HttpGet("{id}", Name ="GetServer")]
        public Server Get(int id)
        {
            return _ctx.Servers.Find(id);
        }

        // POST api/server
        [HttpPost]
        public IActionResult Post([FromBody] Server server)
        {
            if (server == null)
            {
                return BadRequest();
            }

            _ctx.Servers.Add(server);
            _ctx.SaveChanges();

            return CreatedAtRoute("GetServer", new { id = server.Id }, server);
        }

        [HttpPatch("message")]
        public IActionResult Message([FromBody] ServerMessage msg)
        {
            if (msg == null)
            {
                return BadRequest();
            }

            var server = _ctx.Servers.FirstOrDefault(s => s.Id == msg.Id);

            if (server == null)
            {
                return NotFound();
            }

            if(msg.Payload == "activate")
            {
                server.IsOnline = true;
                _ctx.SaveChanges();
            }

            if(msg.Payload == "deactivate")
            {
                server.IsOnline = false;
                _ctx.SaveChanges();
            }

            return new NoContentResult();
        }

        // PUT api/server/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Server server)
        {
            if (server == null || server.Id != id)
            {
                return BadRequest();
            }

            var updatedServer = _ctx.Servers.FirstOrDefault(c => c.Id == id);

            if (updatedServer == null)
            {
                return NotFound();
            }

            updatedServer.IsOnline = server.IsOnline;

            _ctx.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/server/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var server = _ctx.Servers.FirstOrDefault(t => t.Id == id);
            if (server == null)
            {
                return NotFound();
            }

            _ctx.Servers.Remove(server);
            _ctx.SaveChanges();
            return new NoContentResult();
        }
    }
}
