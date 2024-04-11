using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsClubs.Data;
using StudentsClubs.Models;

namespace StudentsClubs.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var objEventList = _db.Events.ToList();
            return View(objEventList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Events Obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string eventPath = Path.Combine(wwwRootPath, @"images/event");
                    if (!Directory.Exists(eventPath))
                        Directory.CreateDirectory(eventPath);

                    if (!string.IsNullOrEmpty(Obj.Description))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, Obj.Description.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    string filePath = Path.Combine(eventPath, fileName);

                    using (var fileStream = new FileStream(Path.Combine(eventPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    Obj.Description = @"images/event/" + fileName;
                }
                _db.Events.Add(Obj);
                _db.SaveChanges();

                var notification = new Notification
                {
                    Message = $"A new event, {Obj.Title}, has been added.",
                    NotificationDate = DateTime.Now,
                    IsRead = false,
                    EventId = Obj.Id
                };

                _db.Notifications.Add(notification);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Events? eventFromDb = _db.Events.Find(id);

            if (eventFromDb == null)
            {
                return NotFound();
            }
            return View(eventFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Events obj)
        {
            if (ModelState.IsValid)
            {
                var eventFromDb = _db.Events.FirstOrDefault(a => a.Id == obj.Id);

                if (eventFromDb != null)
                {
                    eventFromDb.Title = obj.Title;
                    eventFromDb.Description = obj.Description;
                    eventFromDb.EventDate = obj.EventDate;

                    _db.SaveChanges();
                    TempData["success"] = "Event updated successfully.";
                    return RedirectToAction("Index");
                }
            }
            return View(obj);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Events? eventFromDb = _db.Events.FirstOrDefault(u => u.Id == id);

            if (eventFromDb == null)
            {
                return NotFound();
            }
            return View(eventFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Events? obj = _db.Events.FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Events.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Event deleted successfully";
            return RedirectToAction("Index");
        }
    }

}