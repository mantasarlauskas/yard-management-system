using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yard_management_system.Models;
using Microsoft.EntityFrameworkCore;

namespace yard_management_system.Controllers
{

    public class RampController : Controller
    {
        private readonly yard_management_systemContext _context;

        public RampController(yard_management_systemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Message"] = "Rampų sąrašas";
            return View(await _context.Ramp.ToListAsync());
        }
    }
}