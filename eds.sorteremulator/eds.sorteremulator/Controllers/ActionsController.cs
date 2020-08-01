using eds.sorteremulator.services.Configurations.Actions;
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
        private readonly IPhysicsService _physicsService;

        public ActionsController(INodesService nodesService, IPhysicsService physicsService)
        {
            _nodesService = nodesService;
            _physicsService = physicsService;
        }
        [HttpGet]
        public IEnumerable<ActionConfig> Get()
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
        public IActionResult Post([FromBody]ActionConfig value)
        {
            var newNode = _nodesService.AddAction(value);
            return Ok(newNode);
        }
        [HttpPost("Execute/{id}")]
        public IActionResult ExecuteAction(string id)
        {
            var actionConfig = _nodesService.GetActionById(new Guid(id));
            _physicsService.ExecuteManualActionConfig(actionConfig);
            return Ok(actionConfig.Name);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]ActionConfig value)
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
