using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Home()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Tasks(List<TaskItemModel> model)
        {
            foreach (var item in model)
            {
                var task = await _context.TaskItems.FindAsync(item.Id);
                task.IsDone = item.IsDone;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Tasks");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Tasks()
        {      
            var username = User.Identity.Name;
            var tasks = await _context.TaskItems.Where(t => t.UserId == _userManager.GetUserId(User)).ToListAsync();
            return View(tasks);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(TaskItemModel model)
        {
            model.UserId = _userManager.GetUserId(User);
            model.TimeOfPublication = DateTime.UtcNow;
            model.IsDone = false;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.TaskItems.Add(model);
            await _context.SaveChangesAsync();
            return View(new TaskItemModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
