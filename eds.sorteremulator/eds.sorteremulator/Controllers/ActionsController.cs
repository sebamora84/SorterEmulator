using eds.sorteremulator.services.Configurations.NodeActionConfig;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eds.sorteremulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionsController : Controller
    {
        private readonly INodesService _nodesService;

        public ActionsController(INodesService nodesService)
        {
            _nodesService = nodesService;
        }
        [HttpGet]
        public IEnumerable<NodeActionConfig> Get()
        {
            return _nodesService.GetAllActions();
        }


        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var action = _nodesService.GetActionById(new Guid(id));
            return Ok(action);
        }

        [HttpGet("ByNode/{id}")]
        public IActionResult GetByNodeId(string id)
        {
            var actions = _nodesService.GetActionsByNodeId(new Guid(id));
            return Ok(actions);
        }

        [HttpPost]
        public IActionResult Post(NodeActionConfig value)
        {
            var newNode = _nodesService.AddAction(value);
            return Ok(newNode);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]NodeActionConfig value)
        {
            var updatedNode = _nodesService.UpdateAction(new Guid(id), value);
            return Ok(updatedNode);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var removedNode = _nodesService.DeleteAction(new Guid(id));
            return Ok(removedNode);
        }
    }
}
