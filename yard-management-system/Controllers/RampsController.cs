using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using yard_management_system.Models;

namespace yard_management_system.Controllers
{
    public class RampsController : Controller
    {
        private readonly yard_management_systemContext _context;

        public RampsController(yard_management_systemContext context)
        {
            _context = context;
        }

        // GET: Ramps
        public async Task<IActionResult> Index()
        {
            var yard_management_systemContext = _context.Ramp.Include(r => r.UserCreator);
            return View(await yard_management_systemContext.ToListAsync());
        }

        // GET: Ramps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramp = await _context.Ramp
                .Include(r => r.UserCreator)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ramp == null)
            {
                return NotFound();
            }

            return View(ramp);
        }

        // GET: Ramps/Create
        public IActionResult Create()
        {
            ViewData["UserCreatorID"] = new SelectList(_context.User, "UserID", "UserID");
            return View();
        }

        // POST: Ramps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,CategoryOfRamp,Blocked,BlockedFrom,BlockedTo,ID,CreationDate,UserCreatorID")] Ramp ramp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ramp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserCreatorID"] = new SelectList(_context.User, "UserID", "UserID", ramp.UserCreatorID);
            return View(ramp);
        }

        // GET: Ramps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramp = await _context.Ramp.FindAsync(id);
            if (ramp == null)
            {
                return NotFound();
            }
            ViewData["UserCreatorID"] = new SelectList(_context.User, "UserID", "UserID", ramp.UserCreatorID);
            return View(ramp);
        }

        // POST: Ramps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Code,CategoryOfRamp,Blocked,BlockedFrom,BlockedTo,ID,CreationDate,UserCreatorID")] Ramp ramp)
        {
            if (id != ramp.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ramp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RampExists(ramp.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserCreatorID"] = new SelectList(_context.User, "UserID", "UserID", ramp.UserCreatorID);
            return View(ramp);
        }

        // GET: Ramps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramp = await _context.Ramp
                .Include(r => r.UserCreator)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ramp == null)
            {
                return NotFound();
            }

            return View(ramp);
        }

        // POST: Ramps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ramp = await _context.Ramp.FindAsync(id);
            _context.Ramp.Remove(ramp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RampExists(int id)
        {
            return _context.Ramp.Any(e => e.ID == id);
        }
    }
}
