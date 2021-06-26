using eds.sorteremulator.communiation;
using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eds.sorteremulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommunicationController : Controller
    {
        private CommunicationConfig Config
        {
            get => _configurationManager.GetConfig<CommunicationConfig>();
            set => _configurationManager.SaveConfig(value);
        }

        private readonly IConfigurationManager _configurationManager;
        private readonly ICommunicationManager _communicationManager;

        public CommunicationController(IConfigurationManager configurationManager)
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
        public IActionResult Post([FromBody]CommunicationConfig value)
        {
            Config = value;
            return Ok(Config);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CommunicationConfig value)
        {
            Config = value;
            return Ok(Config);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("");
        }
    }
}
