using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using eds.sorter.emulator.configuration;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Services.Interfaces;

namespace eds.sorter.emulator.web.Api
{
    public class PhysicsController : ApiController
    {
        private static PhysicsConfig Config
        {
            get => ConfigurationManager.GetConfig<PhysicsConfig>();
            set => ConfigurationManager.SaveConfig(value);
        }
        private readonly IPhysicsService _physicsService;

        public PhysicsController(IPhysicsService physicsService)
        {
            _physicsService = physicsService;
        }

        public IEnumerable<string> Get()
        {
            return new[] {""};
        }

        // GET api/values/5 
        public IHttpActionResult Get(int id)
        {
            
            return  Ok(Config);

        }

        // POST api/values 
        public IHttpActionResult Post([FromBody]PhysicsConfig value)
        {
            Config = value;
            return Ok(Config);
        }

        // PUT api/values/5 
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Ok("");
        }

        // DELETE api/values/5 
        public IHttpActionResult Delete(int id)
        {
            return Ok("");
        }
    }
}
