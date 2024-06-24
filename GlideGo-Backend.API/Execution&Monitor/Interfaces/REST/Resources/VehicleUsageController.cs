using GlideGo_Backend.API.Execution_Monitor.Application.Internal.CommandServices;
using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GlideGo_Backend.API.Execution_Monitor.Interfaces.REST.Resources;

[Route("api/[controller]")]
[ApiController]
public class VehicleUsageController : ControllerBase
{
    private readonly VehicleUsageCommandService _service;

    public VehicleUsageController(VehicleUsageCommandService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehicleUsage>>> Get()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VehicleUsage>> Get(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VehicleUsage vehicleUsage)
    {
        await _service.AddAsync(vehicleUsage);
        return CreatedAtAction(nameof(Get), new { id = vehicleUsage.Id }, vehicleUsage);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] VehicleUsage vehicleUsage)
    {
        await _service.UpdateAsync(id, vehicleUsage);
        return NoContent();
    }
}