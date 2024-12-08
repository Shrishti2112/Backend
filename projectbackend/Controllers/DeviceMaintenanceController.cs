using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Models;
using SmartHomeAPI.Data; 
namespace SmartHomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceMaintenanceController : ControllerBase
    {
        private readonly SmartHomeDbContext _context;

        public DeviceMaintenanceController(SmartHomeDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceMaintenance>>> GetDeviceMaintenance()
        {
            return await _context.DeviceMaintenance.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceMaintenance>> GetDeviceMaintenance(int id)
        {
            var maintenance = await _context.DeviceMaintenance.FindAsync(id);

            if (maintenance == null)
            {
                return NotFound();
            }

            return maintenance;
        }

        
        [HttpPost]
        public async Task<ActionResult<DeviceMaintenance>> PostDeviceMaintenance(DeviceMaintenance deviceMaintenance)
        {
            _context.DeviceMaintenance.Add(deviceMaintenance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeviceMaintenance", new { id = deviceMaintenance.MaintenanceId }, deviceMaintenance);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeviceMaintenance(int id, DeviceMaintenance deviceMaintenance)
        {
            if (id != deviceMaintenance.MaintenanceId)
            {
                return BadRequest();
            }

            _context.Entry(deviceMaintenance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceMaintenanceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeviceMaintenance>> DeleteDeviceMaintenance(int id)
        {
            var maintenance = await _context.DeviceMaintenance.FindAsync(id);
            if (maintenance == null)
            {
                return NotFound();
            }

            _context.DeviceMaintenance.Remove(maintenance);
            await _context.SaveChangesAsync();

            return maintenance;
        }

        private bool DeviceMaintenanceExists(int id)
        {
            return _context.DeviceMaintenance.Any(e => e.MaintenanceId == id);
        }
    }
}
