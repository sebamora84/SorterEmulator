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
using eds.sorter.emulator.web.Dto;

namespace eds.sorter.emulator.web.Api
{
    public class ParcelsController : ApiController
    {
        private readonly IPhysicsService _physicsService;
        private readonly IParcelService _parcelsService;
        private readonly INodesService _nodesService;

        public ParcelsController(IPhysicsService physicsService,IParcelService parcelsService, INodesService nodesService)
        {
            _physicsService = physicsService;
            _parcelsService = parcelsService;
            _nodesService = nodesService;
        }
        [HttpGet]
        public IEnumerable<Parcel> Get()
        {
             return _parcelsService.GetAllParcels();
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        { 
            return Ok(_parcelsService.GetParcel(id));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] NewParcelDto value)
        {
            var node = _nodesService.GetNode(new Guid(value.NodeId));
            if (node == null)
            {
                return BadRequest($"No node with Id {value.NodeId}");
            }
            if (string.IsNullOrEmpty(value.BarcodeToRead))
            {
                var parcel = _parcelsService.AddNewParcel(node, weightToWeigh: value.WeightToWeigh);
                _physicsService.AddTracking(parcel.Pic, node.Id, 0);
                return Ok(parcel);
            }
            var parcelWithBarcode = _parcelsService.AddNewParcel(node, value.BarcodeToRead, value.WeightToWeigh);
            _physicsService.AddTracking(parcelWithBarcode.Pic, node.Id, 0);
            return Ok(parcelWithBarcode);
        }

        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody]Node value)
        {
            return Ok("");
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            _parcelsService.RemoveParcel(int.Parse(id));
            _physicsService.RemoveTrackingByPic(int.Parse(id));
            return Ok("Parcel removed");
        }
    }
}
