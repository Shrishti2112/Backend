using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartHomeAPI.Data;

namespace SmartHomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly SmartHomeDbContext _context;

        
        public RoomController(SmartHomeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);

           
            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

       
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            
            _context.Rooms.Add(room);

           
            await _context.SaveChangesAsync();

           
            return CreatedAtAction("GetRoom", new { id = room.RoomId }, room);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
           
            if (id != room.RoomId)
            {
                return BadRequest();
            }

            
            _context.Entry(room).State = EntityState.Modified;

            try
            {
               
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               
                if (!_context.Rooms.Any(r => r.RoomId == id))
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
        public async Task<IActionResult> DeleteRoom(int id)
        {
           
            var room = await _context.Rooms.FindAsync(id);

           
            if (room == null)
            {
                return NotFound();
            }

            
            _context.Rooms.Remove(room);

            await _context.SaveChangesAsync();

            return NoContent(); 
        }
    }
}
