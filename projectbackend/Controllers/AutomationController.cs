using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Models;
using SmartHomeAPI.Data;
namespace SmartHomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomationController : ControllerBase
    {
        private readonly SmartHomeDbContext _context;

        public AutomationController(SmartHomeDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Automation>>> GetAutomations()
        {
            var suto = await _context.Automations.ToListAsync();
            return suto;
        }

       
        [HttpPost]
        public async Task<ActionResult<Automation>> CreateAutomation(Automation automation)
        {
            _context.Automations.Add(automation);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAutomations), new { id = automation.AutomationId }, automation);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAutomation(int id, Automation automation)
        {
            if (id != automation.AutomationId)
                return BadRequest();

            _context.Entry(automation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutomation(int id)
        {
            var automation = await _context.Automations.FindAsync(id);
            if (automation == null)
                return NotFound();

            _context.Automations.Remove(automation);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
