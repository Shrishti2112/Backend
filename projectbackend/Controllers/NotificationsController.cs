using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Models;
using SmartHomeAPI.Data;
[Route("api/[controller]")]
[ApiController]
public class NotificationsController : ControllerBase
{
    private readonly SmartHomeDbContext _context;

    public NotificationsController(SmartHomeDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddNotification([FromBody] Notification notification)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetNotification), new { id = notification.NotificationId }, notification);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Notification>> GetNotification(int id)
    {
        var notification = await _context.Notifications.FindAsync(id);
        if (notification == null)
            return NotFound();

        return notification;
    }
}
