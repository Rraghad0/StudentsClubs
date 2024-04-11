using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsClubs.Data;
using StudentsClubs.Models;
using System.Diagnostics;
using System.Security.Claims;


namespace StudentsClubs.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var clubs = _db.Clubs.ToList();
            return View(clubs);
        }

        public IActionResult Details(int id)
        {
            ViewBag.IsMember = false;
            var club = _db.Clubs.FirstOrDefault(i => i.ClubID == id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
