using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Models;
using SmartHomeAPI.Data;
[Route("api/[controller]")]
[ApiController]
public class VoiceCommandsController : ControllerBase
{
    private readonly SmartHomeDbContext _context;

    public VoiceCommandsController(SmartHomeDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddVoiceCommand([FromBody] VoiceCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var device = await _context.Devices.FindAsync(command.DeviceId);
        if (device == null)
            return BadRequest("Invalid DeviceId.");

        _context.VoiceCommands.Add(command);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetVoiceCommand), new { id = command.CommandId }, command);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VoiceCommand>> GetVoiceCommand(int id)
    {
        var command = await _context.VoiceCommands.FindAsync(id);
        if (command == null)
            return NotFound();

        return command;
    }
}
