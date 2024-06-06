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
    public async Task<ActionResult<VehicleUsage>> Get(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VehicleUsageDto dto)
    {
        await _service.AddAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = dto.VehicleId }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] VehicleUsageDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return NoContent();
    }
}