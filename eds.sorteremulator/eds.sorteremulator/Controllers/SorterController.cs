using eds.sorteremulator.services.Configurations.Nodes;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eds.sorteremulator.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SorterController : Controller
    {
        private readonly INodesService _nodesService;

        public SorterController(INodesService nodesService)
        {
            _nodesService = nodesService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]NodeConfig value)
        {
            var node = _nodesService.GetNode(new Guid(id));
            if (node == null)
                return BadRequest($"Node with Id {id} does not exist");
            node.IsStopped = value.IsStopped;
            return Ok(node);
        }
    }
}
