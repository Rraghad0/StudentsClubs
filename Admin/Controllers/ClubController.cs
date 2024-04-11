using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsClubs.Data;
using StudentsClubs.Models;

namespace StudentsClubs.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;


        public ClubController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _context = context;

        }
        public IActionResult Index()
        {
            List<Club> objClubList = _db.Clubs.ToList();
            return View(objClubList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Club Obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string clubPath = Path.Combine(wwwRootPath, @"images\club");
                    if (!Directory.Exists(clubPath))
                        Directory.CreateDirectory(clubPath);

                    string filePath = Path.Combine(clubPath, fileName);

                    using (var fileStream = new FileStream(Path.Combine(clubPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    Obj.LogoURL = @"images\club" + fileName;
                }

            }
            _db.Clubs.Add(Obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id != null || id != 0)
            {
                Club clubFromDb = _db.Clubs.Find(id);
                return View(clubFromDb);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Club Obj,  IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                Club clubFromDb = _db.Clubs.First(u => u.ClubID == Obj.ClubID);
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null && file.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string clubPath = Path.Combine(wwwRootPath, @"images\club");

                    if (!string.IsNullOrEmpty(clubFromDb.LogoURL))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, clubFromDb.LogoURL.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(clubPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    clubFromDb.LogoURL = @"images\club\" + fileName;
                    clubFromDb.LogoURL = Obj.LogoURL;

                }
                clubFromDb.ClubName = Obj.ClubName;
                clubFromDb.Description = Obj.Description;
                clubFromDb.WhatsAppGroupLink = Obj.WhatsAppGroupLink;
                clubFromDb.ClubType = Obj.ClubType;

                _db.SaveChanges();
                TempData["success"] = "Club updated successfully.";
                return RedirectToAction("Index");
            }
            return View(Obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Club? clubFromDb = _db.Clubs.FirstOrDefault(u => u.ClubID == id);

            if (clubFromDb == null)
            {
                return NotFound();
            }
            return View(clubFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Club? obj = _db.Clubs.FirstOrDefault(u => u.ClubID == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Clubs.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Club deleted successfully";
            return RedirectToAction("Index");
        }
    }

}