using GlideGo_Backend.API.Execution_Monitor.Application.Internal.CommandServices;
using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GlideGo_Backend.API.Execution_Monitor.Interfaces.REST.Resources;

[Route("api/[controller]")]
[ApiController]
public class ActiveServicesController : ControllerBase
{
    private readonly ActiveServicesCommandService _service;
    
    public ActiveServicesController(ActiveServicesCommandService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActiveServices>>> Get()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ActiveServices>> Get(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ActiveServices activeServices)
    {
        await _service.AddAsync(activeServices);
        return CreatedAtAction(nameof(Get), new { id = activeServices.Id }, activeServices);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] ActiveServices activeServices)
    {
        await _service.UpdateAsync(id, activeServices);
        return NoContent();
    }
}