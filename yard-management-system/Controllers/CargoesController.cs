﻿using System;
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

        public CargoesController(yard_management_systemContext context)
        {
            _context = context;
        }


        // GET: Cargoes/Details/5
        public async Task<IActionResult> Details(int? id)
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

            ViewData["ID"] = id;
            ViewData["EntryID"] = new SelectList(_context.Entry, "ID", "Code");
            ViewData["RampID"] = new SelectList(_context.Ramp, "ID", "Code");
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

            ViewData["ID"] = id;
            ViewData["EntryID"] = new SelectList(_context.Entry, "ID", "Code");
            ViewData["RampID"] = new SelectList(_context.Ramp, "ID", "Code");
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
            ViewData["EntryID"] = new SelectList(_context.Entry, "ID", "Discriminator", cargo.EntryID);
            ViewData["OrderID"] = new SelectList(_context.Order, "ID", "Discriminator", cargo.OrderID);
            ViewData["RampID"] = new SelectList(_context.Ramp, "ID", "Discriminator", cargo.RampID);
            return View(cargo);
        }

        // POST: Cargoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RegistrationNumber,Weight,Description,State,RampID,EntryID,OrderID")] Cargo cargo)
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
            ViewData["EntryID"] = new SelectList(_context.Entry, "ID", "Discriminator", cargo.EntryID);
            ViewData["OrderID"] = new SelectList(_context.Order, "ID", "Discriminator", cargo.OrderID);
            ViewData["RampID"] = new SelectList(_context.Ramp, "ID", "Discriminator", cargo.RampID);
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