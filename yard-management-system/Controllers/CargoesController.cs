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
    public class CargoesController : Controller
    {
        private readonly yard_management_systemContext _context;
        private readonly MessagesController _messagesCtrl;

        public CargoesController(yard_management_systemContext context, MessagesController messagesCtrl)
        {
            _context = context;
            _messagesCtrl = messagesCtrl;
        }

        // GET: Cargoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo
                .Include("Entry")
                .Include("Order")
                .Include("Ramp")
                .Include("CargoTimeSlots")
                .Include("CargoTimeSlots.TimeSlot")
                .Include("OrderContracts")
                .Include("OrderContracts.Contractor")
                .Include("OrderContracts.Contractor.User")
                .FirstOrDefaultAsync(m => m.ID == id);

            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // GET: Cargoes/Create/5
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.UserCreator)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (order == null)
            {
                return NotFound();
            }

            var ramps = _context.Ramp
                .Select(r => new
                {
                    ID = r.ID,
                    Description = string.Format("Kodas: {0}, Transporto kategorija: {1}", r.Code, r.CategoryOfRamp)
                });
            ViewData["ID"] = id;
            ViewData["EntryID"] = new SelectList(_context.Entry, "ID", "Code");
            ViewData["RampID"] = new SelectList(ramps, "ID", "Description");
            return View();
        }

        // POST: Cargoes/Create/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistrationNumber,Weight,Description,RampID,EntryID")] Cargo cargo, int id)
        {
            cargo.OrderID = id;
            cargo.State = Cargo.CargoState.ruošiamas;

            if (ModelState.IsValid)
            {
                _context.Add(cargo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Orders", new { id = cargo.OrderID });
            }

            var ramps = _context.Ramp
                .Select(r => new
                {
                    ID = r.ID,
                    Description = string.Format("Kodas: {0}, Transporto kategorija: {1}", r.Code, r.CategoryOfRamp)
                });
            ViewData["ID"] = id;
            ViewData["EntryID"] = new SelectList(_context.Entry, "ID", "Code");
            ViewData["RampID"] = new SelectList(ramps, "ID", "Description");
            return View(cargo);
        }

        // GET: Cargoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo.FindAsync(id);

            if (cargo == null)
            {
                return NotFound();
            }

            var ramps = _context.Ramp
                .Select(r => new
                {
                    ID = r.ID,
                    Description = string.Format("Kodas: {0}, Transporto kategorija: {1}", r.Code, r.CategoryOfRamp)
                });
            ViewData["State"] = cargo.State;
            ViewData["EntryID"] = new SelectList(_context.Entry, "ID", "Code");
            ViewData["RampID"] = new SelectList(ramps, "ID", "Description");
            return View(cargo);
        }

        // POST: Cargoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string prevState,
            [Bind("ID,RegistrationNumber,Weight,Description,State,RampID,EntryID,OrderID")] Cargo cargo)
        {
            if (id != cargo.ID)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargo);
                    await _context.SaveChangesAsync();
                    string currentState = cargo.State.ToString();
                    if (prevState != currentState)
                    {
                        await _messagesCtrl.CreateMessage(id, prevState, currentState);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoExists(cargo.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Orders", new { id = cargo.OrderID });
            }

            var ramps = _context.Ramp
                .Select(r => new
                {
                    ID = r.ID,
                    Description = string.Format("Kodas: {0}, Transporto kategorija: {1}", r.Code, r.CategoryOfRamp)
                });
            ViewData["EntryID"] = new SelectList(_context.Entry, "ID", "Code");
            ViewData["RampID"] = new SelectList(ramps, "ID", "Description");
            return View(cargo);
        }

        // GET: Cargoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo
                .Include(c => c.Entry)
                .Include(c => c.Order)
                .Include(c => c.Ramp)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // POST: Cargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargo = await _context.Cargo.FindAsync(id);
            _context.Cargo.Remove(cargo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Orders", new { id = cargo.OrderID });
        }

        private bool CargoExists(int id)
        {
            return _context.Cargo.Any(e => e.ID == id);
        }
    }
}
