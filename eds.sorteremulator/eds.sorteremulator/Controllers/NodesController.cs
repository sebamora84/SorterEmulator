using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eds.sorteremulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NodesController : Controller
    {
        private readonly INodesService _nodesService;

        public NodesController(INodesService nodesService)
        {
            _nodesService = nodesService;
        }
        [HttpGet]
        public IEnumerable<Node> Get()
        {
             return _nodesService.GetAllNodes();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(_nodesService.GetNode(new Guid(id)));
        }

        [HttpPost]
        public IActionResult Post(Node value)
        {
            var newNode =_nodesService.AddNode(value);
            return Ok(newNode);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Node value)
        {
            var updatedNode = _nodesService.UpdateNode(new Guid(id), value);
            return Ok(updatedNode);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var removedNode = _nodesService.DeleteNode(new Guid(id));
            return Ok(removedNode);
        }
    }
}
