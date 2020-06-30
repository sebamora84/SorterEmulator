using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eds.sorteremulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackingController : Controller
    {
        private readonly IPhysicsService _physicsService;

        public TrackingController(IPhysicsService physicsService)
        {
            _physicsService = physicsService;
        }
        [HttpGet]
        public IEnumerable<Tracking> Get()
        {
            return _physicsService.GetAllTracking();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            
            return  Ok("");

        }

        [HttpPost]
        public IActionResult Post([FromBody] int value)
        {
            return Ok("");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return Ok("");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok("");
        }
    }
}
