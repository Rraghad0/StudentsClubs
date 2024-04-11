using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsClubs.Data;
using StudentsClubs.Models;

namespace StudentsClubs.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MembershipController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;


        public MembershipController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        public IActionResult Index()
        {
            List<Membership> objMembershipList = _db.Memberships.ToList();
            return View(objMembershipList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Membership Obj)
        {
            _db.Memberships.Add(Obj);
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

            var membershipFromDb = _db.Memberships.FirstOrDefault(u => u.Id == id);

            if (membershipFromDb == null)
            {
                return NotFound();
            }

            return View(membershipFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Membership obj)
        {
            if (ModelState.IsValid)
            {
                var membershipFromDb = _db.Memberships.FirstOrDefault(a => a.Id == obj.Id);

                if (membershipFromDb != null)
                {
                    membershipFromDb.Name = obj.Name;
                    membershipFromDb.Role = obj.Role;

                    _db.SaveChanges();
                    TempData["success"] = "Member updated successfully.";
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
            Membership? membershipFromDb = _db.Memberships.FirstOrDefault(u => u.Id == id);

            if (membershipFromDb == null)
            {
                return NotFound();
            }
            return View(membershipFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Membership? obj = _db.Memberships.FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Memberships.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Member deleted successfully";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public async Task<IActionResult> ListClubMembers(string clubName)
        {
            var clubMembers = await _context.Memberships
                                            .Where(m => m.ClubName == clubName)
                                            .ToListAsync();

            if (!clubMembers.Any())
            {
                return NotFound($"No members found for {clubName}.");
            }

            ViewBag.ClubName = clubName;
            return View("ListClubMembers", clubMembers);
        }

    }
}
