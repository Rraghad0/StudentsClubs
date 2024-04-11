using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsClubs.Data;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class VolunteerController : Controller
{
    private readonly ApplicationDbContext _context;

    public VolunteerController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var volunteers = await _context.Volunteers.ToListAsync();
        return View(volunteers);
    }
}
