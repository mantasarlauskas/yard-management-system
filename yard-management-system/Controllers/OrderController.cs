using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yard_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace yard_management_system.Controllers
{
    public class OrderController : Controller
    {
        private readonly yard_management_systemContext _context;

        public OrderController(yard_management_systemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Message"] = "Užsakymų sąrašas";
            return View(await _context.CargoTimeSlot.ToListAsync());
        }
    }
}