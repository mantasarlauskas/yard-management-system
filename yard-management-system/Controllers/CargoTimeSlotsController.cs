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
    public class CargoTimeSlotsController : Controller
    {
        private readonly yard_management_systemContext _context;

        public CargoTimeSlotsController(yard_management_systemContext context)
        {
            _context = context;
        }

        // GET: CargoTimeSlots/Create/5
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo
                .FirstOrDefaultAsync(m => m.ID == id);

            if (cargo == null)
            {
                return NotFound();
            }

            var timeSlots = _context.TimeSlot
                .Where(t => t.Blocked == false)
                .Where(t => t.Reserved == false)
                .Where(t => t.RampID == cargo.RampID)
                .Where(t => t.Date > DateTime.Now)
                .Select(s => new
                {
                    TimeSlotID = s.TimeSlotID,
                    Description = string.Format("Tipas: {0}, Data: {1}, Laikas nuo: {2}, Trukmė: {3}", 
                        s.TypeOfTimeSlot, s.Date.Date.ToString("yyyy-MM-dd"), s.TimeFrom, s.TimeDuration)
                });


            ViewData["ID"] = id;
            ViewData["TimeSlotID"] = new SelectList(timeSlots, "TimeSlotID", "Description");
            var timeSlotsList = await timeSlots.ToListAsync();
            ViewData["count"] = timeSlotsList.Count;
            return View();
        }

        // POST: CargoTimeSlots/Create/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeSlotID")] CargoTimeSlot cargoTimeSlot, int id)
        {
            cargoTimeSlot.CargoID = id;
            if (ModelState.IsValid)
            {
                var timeSlot = await _context.TimeSlot
                .FirstOrDefaultAsync(m => m.TimeSlotID == cargoTimeSlot.TimeSlotID);
                timeSlot.Reserved = true;
                _context.Add(cargoTimeSlot);
                _context.Update(timeSlot);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Cargoes", new { id = cargoTimeSlot.CargoID });
            }

            var cargo = await _context.Cargo
                .FirstOrDefaultAsync(m => m.ID == id);

            var timeSlots = _context.TimeSlot
               .Where(t => t.Blocked == false)
               .Where(t => t.Reserved == false)
               .Where(t => t.RampID == cargo.RampID)
               .Where(t => t.Date > DateTime.Now);


            ViewData["ID"] = id;
            ViewData["TimeSlotID"] = new SelectList(timeSlots, "TimeSlotID", "Date");
            var timeSlotsList = await timeSlots.ToListAsync();
            ViewData["count"] = timeSlotsList.Count;
            return View(cargoTimeSlot);
        }

        // GET: CargoTimeSlots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoTimeSlot = await _context.CargoTimeSlot
                .Include(c => c.Cargo)
                .Include(c => c.TimeSlot)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (cargoTimeSlot == null)
            {
                return NotFound();
            }

            return View(cargoTimeSlot);
        }

        // POST: CargoTimeSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargoTimeSlot = await _context.CargoTimeSlot.FindAsync(id);
            var timeSlot = await _context.TimeSlot.FindAsync(cargoTimeSlot.TimeSlotID);
            timeSlot.Reserved = false;
            _context.Update(timeSlot);
            _context.CargoTimeSlot.Remove(cargoTimeSlot);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Cargoes", new { id = cargoTimeSlot.CargoID });
        }

        private bool CargoTimeSlotExists(int id)
        {
            return _context.CargoTimeSlot.Any(e => e.ID == id);
        }
    }
}
