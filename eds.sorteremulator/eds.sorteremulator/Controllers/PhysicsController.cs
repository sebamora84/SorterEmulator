using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eds.sorteremulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhysicsController : Controller
    {
        private PhysicsConfig Config
        {
            get => _configurationManager.GetConfig<PhysicsConfig>();
            set => _configurationManager.SaveConfig(value);
        }

        private readonly IConfigurationManager _configurationManager;

        public PhysicsController(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Config);
        }

        // GET api/values/5 
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            
            return  Ok(Config);

        }

        [HttpPost]
        public IActionResult Post([FromBody]PhysicsConfig value)
        {
            Config = value;
            return Ok(Config);
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return Ok("");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok("");
        }
    }
}
