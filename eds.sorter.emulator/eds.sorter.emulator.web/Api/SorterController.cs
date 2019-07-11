using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.Services.Interfaces;

namespace eds.sorter.emulator.web.Api
{
    public class SorterController : ApiController
    {
        private readonly INodesService _nodesService;

        public SorterController(INodesService nodesService)
        {
            _nodesService = nodesService;
        }
        [HttpGet]
        public IEnumerable<Node> Get()
        {
           return new List<Node>();
        }

        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            return Ok("");
        }

        [HttpPost]
        public IHttpActionResult Post(Node value)
        {
            return Ok("");
        }

        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody]Node value)
        {
            var node = _nodesService.GetNode(new Guid(id));
            if (node == null)
                return BadRequest($"Node with Id {id} does not exist");
            node.IsStopped = value.IsStopped;
            return Ok(node);
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            return Ok("");
        }
    }
}
