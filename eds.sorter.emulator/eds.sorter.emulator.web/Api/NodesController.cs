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
    public class NodesController : ApiController
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

        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            return Ok(_nodesService.GetNode(new Guid(id)));
        }

        [HttpPost]
        public IHttpActionResult Post(Node value)
        {
            var newNode =_nodesService.AddNode(value);
            return Ok(newNode);
        }

        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody]Node value)
        {
            var updatedNode = _nodesService.UpdateNode(new Guid(id), value);
            return Ok(updatedNode);
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var removedNode = _nodesService.DeleteNode(new Guid(id));
            return Ok(removedNode);
        }
    }
}
