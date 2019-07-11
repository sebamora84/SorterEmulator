using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using eds.sorter.emulator.configuration;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.Services.Interfaces;

namespace eds.sorter.emulator.web.Api
{
    public class TrackingController : ApiController
    {
        private readonly IPhysicsService _physicsService;

        public TrackingController(IPhysicsService physicsService)
        {
            _physicsService = physicsService;
        }

        public IEnumerable<Tracking> Get()
        {
            return _physicsService.GetAllTracking();
        }

        // GET api/values/5 
        public IHttpActionResult Get(int id)
        {
            
            return  Ok("");

        }

        // POST api/values 
        public IHttpActionResult Post([FromBody] int value)
        {
            return Ok("");
        }

        // PUT api/values/5 
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Ok("");
        }

        // DELETE api/values/5 
        public IHttpActionResult Delete(string id)
        {
            return Ok("");
        }
    }
}
