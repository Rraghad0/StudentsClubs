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
    public class AchievementController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;


        public AchievementController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        public IActionResult Index()
        {
            List<Achievements> objAchievementList = _db.Achievements.ToList();
            return View(objAchievementList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Achievements Obj)
        {
            _db.Achievements.Add(Obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var achievementFromDb = _db.Achievements.FirstOrDefault(u => u.AchievementId == id);

            if (achievementFromDb == null)
            {
                return NotFound();
            }

            return View(achievementFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Achievements obj)
        {
            if (ModelState.IsValid)
            {
                var achievementFromDb = _db.Achievements.FirstOrDefault(a => a.AchievementId == obj.AchievementId);

                if (achievementFromDb != null)
                {
                    achievementFromDb.Description = obj.Description;
                    achievementFromDb.ClubName = obj.ClubName;

                    _db.SaveChanges();
                    TempData["success"] = "Achievement updated successfully.";
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
            Achievements? achievementFromDb = _db.Achievements.FirstOrDefault(u => u.AchievementId == id);

            if (achievementFromDb == null)
            {
                return NotFound();
            }
            return View(achievementFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Achievements? obj = _db.Achievements.FirstOrDefault(u => u.AchievementId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Achievements.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "achievement deleted successfully";
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public async Task<IActionResult> listClubAchievement(string clubName)
        {
            var clubAchievements = await _context.Achievements
                                            .Where(m => m.ClubName == clubName)
                                            .ToListAsync();

            if (!clubAchievements.Any())
            {
                return NotFound($"No achievement found for {clubName}.");
            }

            ViewBag.ClubName = clubName;
            return View("listClubAchievement", clubAchievements);
        }
    }
}