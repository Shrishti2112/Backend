using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Models;
using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Data;
namespace SmartHomeAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly SmartHomeDbContext _context;

        public SecurityController(SmartHomeDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SecurityDevice>>> GetSecurityDevices()
        {
            return await _context.SecurityDevices.ToListAsync();
        }

       
        [HttpPost("{id}/trigger-alert")]
        public async Task<IActionResult> TriggerAlert(int id)
        {
            var device = await _context.SecurityDevices.FindAsync(id);
            if (device == null)
                return NotFound();

            
            device.AlertStatus = "Alert Sent";
            await _context.SaveChangesAsync();
            return Ok("Alert triggered successfully.");
        }
    }

}
