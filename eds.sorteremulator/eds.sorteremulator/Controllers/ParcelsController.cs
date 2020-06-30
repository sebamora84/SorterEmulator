using eds.sorteremulator.Dto;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eds.sorteremulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelsController : Controller
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        { 
            return Ok(_parcelsService.GetParcel(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewParcelDto value)
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
        public IActionResult Put(string id, [FromBody]Node value)
        {
            return Ok("");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _parcelsService.RemoveParcel(int.Parse(id));
            _physicsService.RemoveTrackingByPic(int.Parse(id));
            return Ok("");
        }
    }
}
