using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsClubs.Data;
using StudentsClubs.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsClubs.Areas.Student.Controllers
{
    [Area("Student")]
    public class NotificationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var notifications = await _context.Notifications.OrderByDescending(n => n.NotificationDate).ToListAsync();
            return View(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsRead(int notificationId)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                _context.Notifications.Update(notification);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UnreadCount()
        {
            var count = await _context.Notifications.CountAsync(n => !n.IsRead);
            return Json(count);
        }

    }
}
