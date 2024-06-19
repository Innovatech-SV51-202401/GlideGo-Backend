using ACME.LearningCenterPlatform.API.Design.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Design.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Design.Domain.Services;
using ACME.LearningCenterPlatform.API.Design.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Design.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ACME.LearningCenterPlatform.API.executionandmonitor.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Design.Interfaces.REST.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleCommadService _vehicleCommandService;
        private readonly IVehicleQueryService _vehicleQueryService;

        public VehiclesController(IVehicleCommadService vehicleCommandService, IVehicleQueryService vehicleQueryService)
        {
            _vehicleCommandService = vehicleCommandService;
            _vehicleQueryService = vehicleQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleResource createVehicleResource)
        {
            var createVehicleCommand = CreateVehicleCommandFromResourceAssembler.ToCommandFromResource(createVehicleResource);
            var vehicle = await _vehicleCommandService.Handle(createVehicleCommand);
            if (vehicle is null) return BadRequest();
            var resource = VehicleResource.ToResourceFromEntity(vehicle);
            return CreatedAtAction(nameof(GetVehicleById), new { vehicleId = resource.Id }, resource);
        }

        [HttpGet("{vehicleId}")]
        public async Task<IActionResult> GetVehicleById([FromRoute] int vehicleId)
        {
            var vehicle = await _vehicleQueryService.Handle(new GetVehicleByIdQuery(vehicleId));
            if (vehicle == null) return NotFound();
            var resource = VehicleResource.ToResourceFromEntity(vehicle);
            return Ok(resource);
        }
    }
}