using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Models;

using SmartHomeAPI.Data;
[Route("api/[controller]")]
[ApiController]
public class PreferencesController : ControllerBase
{
    private readonly SmartHomeDbContext _context;

    public PreferencesController(SmartHomeDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddPreference([FromBody] Preference preference)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Preferences.Add(preference);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPreference), new { id = preference.PreferenceId }, preference);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Preference>> GetPreference(int id)
    {
        var preference = await _context.Preferences.FindAsync(id);
        if (preference == null)
            return NotFound();

        return preference;
    }
}
