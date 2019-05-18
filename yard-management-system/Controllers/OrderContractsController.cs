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
    public class OrderContractsController : Controller
    {
        private readonly yard_management_systemContext _context;

        public OrderContractsController(yard_management_systemContext context)
        {
            _context = context;
        }

        // GET: OrderContracts/Create/5
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

            var contractors = await _context.Contractor
                 .Include("User")
                 .ToListAsync();

            var orderContracts = await _context.OrderContract.Where(o => o.CargoID == id).ToListAsync();

            var contractorsList = contractors
                .Where(c => orderContracts.Where(o => o.ContractorID == c.ID).ToList().Count == 0)
                .Select(s => new
                {
                    ID = s.ID,
                    Description = string.Format("Pareigos: {0}, Vardas: {1}, Pavardė: {2}", s.TypeOfContractor, s.User.FirstName, s.User.SecondName)
                })
                .ToList();


            ViewData["ID"] = id;
            ViewData["ContractorID"] = new SelectList(contractorsList, "ID", "Description");
            
            ViewData["count"] = contractorsList.Count;
            return View();
        }

        // POST: OrderContracts/Create/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractorID")] OrderContract orderContract, int id)
        {
            orderContract.CargoID = id;

            if (ModelState.IsValid)
            {
                _context.Add(orderContract);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Cargoes", new { id = orderContract.CargoID });
            }

            var contractors = _context.Contractor
                .Include("User")
                .Select(s => new
                {
                    UserID = s.UserID,
                    Description = string.Format("Pareigos: {0}, Vardas: {1}, Pavardė: {2}", s.TypeOfContractor, s.User.FirstName, s.User.SecondName)
                });

            ViewData["ID"] = id;
            ViewData["ContractorID"] = new SelectList(contractors, "UserID", "Description");
            return View(orderContract);
        }

        // GET: OrderContracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderContract = await _context.OrderContract
                .Include(o => o.Cargo)
                .Include(o => o.Contractor)
                .Include("Cargo")
                .Include("Contractor")
                .Include("Contractor.User")
                .FirstOrDefaultAsync(m => m.ID == id);

            if (orderContract == null)
            {
                return NotFound();
            }

            return View(orderContract);
        }

        // POST: OrderContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderContract = await _context.OrderContract.FindAsync(id);
            _context.OrderContract.Remove(orderContract);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Cargoes", new { id = orderContract.CargoID });
        }

        private bool OrderContractExists(int id)
        {
            return _context.OrderContract.Any(e => e.ID == id);
        }
    }
}
