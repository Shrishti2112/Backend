using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Models;
using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Data;

namespace SmartHomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyController : ControllerBase
    {
        private readonly SmartHomeDbContext _context;

        public EnergyController(SmartHomeDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyUsage>>> GetEnergyUsage()
        {
            return await _context.EnergyUsage.ToListAsync();
        }

        
        [HttpPost]
        public async Task<ActionResult<EnergyUsage>> AddEnergyUsage(EnergyUsage usage)
        {
            _context.EnergyUsage.Add(usage);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEnergyUsage), new { id = usage.UsageId }, usage);
        }
    }

}
