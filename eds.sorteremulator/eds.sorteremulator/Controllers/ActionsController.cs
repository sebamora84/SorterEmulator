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

        [HttpGet("ByNode/{id}")]
        public IActionResult GetByNodeId(string id)
        {
            var actions = _nodesService.GetActions(new Guid(id));
            return Ok(actions);
        }
    }
}
