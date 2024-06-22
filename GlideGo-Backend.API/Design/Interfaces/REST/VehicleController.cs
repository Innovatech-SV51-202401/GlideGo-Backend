using GlideGo_Backend.API.Design.Domain.Model.Aggregates;
using GlideGo_Backend.API.Design.Domain.Model.Queries;
using GlideGo_Backend.API.Design.Domain.Services;
using GlideGo_Backend.API.Design.Interfaces.REST.Resources;
using GlideGo_Backend.API.Design.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace GlideGo_Backend.API.Design.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class VehicleController(
    IVehicleCommandService vehicleCommandService,
    IVehicleQueryService vehicleQueryService
    ): ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateVehicle([FromBody] CreateVehicleResource resource)
    {
        var createVehicleCommand = CreateVehicleCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await vehicleCommandService.Handle(createVehicleCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetVehicleByIdVehicle), new { id = result.Id },
            VehicleResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetVehicleById(int id)
    {
        var getAllVehiclesByIdQuery = new GetVehicleByIdQuery(id);
        var result = await vehicleQueryService.Handle(getAllVehiclesByIdQuery);
        if (result is null) return NotFound();
        var resource = VehicleResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    private async Task<ActionResult> GetVehiclesByIdOwner(int idOwner)
    {
        var getAllVehiclesByIdOwnerQuery = new GetAllVehiclesByIdOwner(idOwner);
        var result = await vehicleQueryService.Handle(getAllVehiclesByIdOwnerQuery);
        var resources = result.Select(VehicleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    private async Task<ActionResult> GetVehiclesByIdVehicleAndOwner(int idVehicle, int idOwner)
    {
        var getAllVehiclesByIdVehicleAndOwnerQuery = new GetVehicleByIdVehicleAndOwner(idVehicle, idOwner);
        var result = await vehicleQueryService.Handle(getAllVehiclesByIdVehicleAndOwnerQuery);
        if (result is null) return NotFound();
        var resource = VehicleResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetVehiclesFromQuery([FromQuery] int idVehicle, [FromQuery] int idOwner)
    {
        if (idVehicle != 0 && idOwner != 0) return await GetVehiclesByIdVehicleAndOwner(idVehicle, idOwner);
        if (idOwner != 0) return await GetVehiclesByIdOwner(idOwner);
        return BadRequest();
    }
}