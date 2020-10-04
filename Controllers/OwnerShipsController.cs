using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vehicle_Ownership_MVC.Models;

namespace Vehicle_Ownership_MVC.Controllers
{
    //Secured ownership controller.
    [Authorize]
    public class OwnerShipsController : Controller
    {
        private readonly Vehicle_Ownership_MVCDataContext _context;

        public OwnerShipsController(Vehicle_Ownership_MVCDataContext context)
        {
            _context = context;
        }

        // GET: OwnerShips
        //Gets all ownerships using a lamda query.
        public IActionResult Index()
        {
            var vehicle_Ownership_MVCDataContext = _context.OwnerShip.Include(o => o.Citizen).Include(o => o.Vehicle);
            return View(vehicle_Ownership_MVCDataContext.ToList());
        }

        // GET: OwnerShips/Details/5
        //Gets the details of the ownership 
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerShip =  _context.OwnerShip
                .Include(o => o.Citizen)
                .Include(o => o.Vehicle)
                .FirstOrDefault(m => m.Id == id);
            if (ownerShip == null)
            {
                return NotFound();
            }

            return View(ownerShip);
        }

        // GET: OwnerShips/Create
        //Gets the ownership form.
        public IActionResult Create()
        {
            ViewData["CitizenId"] = new SelectList(_context.Citizen, "Id", "Name");
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "Id", "RegistrationNumber");
            return View();
        }

        // POST: OwnerShips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds an ownership
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,VehicleId,CitizenId")] OwnerShip ownerShip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownerShip);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CitizenId"] = new SelectList(_context.Citizen, "Id", "Id", ownerShip.CitizenId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "Id", "Id", ownerShip.VehicleId);
            return View(ownerShip);
        }

        // GET: OwnerShips/Edit/5
        //Gets the ownership for update using a linq query
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerShip = (from owner in _context.OwnerShip
                             where owner.Id == id
                             select owner).FirstOrDefault();
            if (ownerShip == null)
            {
                return NotFound();
            }
            ViewData["CitizenId"] = new SelectList(_context.Citizen, "Id", "Name", ownerShip.CitizenId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "Id", "RegistrationNumber", ownerShip.VehicleId);
            return View(ownerShip);
        }

        // POST: OwnerShips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the ownership
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,VehicleId,CitizenId")] OwnerShip ownerShip)
        {
            if (id != ownerShip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownerShip);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerShipExists(ownerShip.Id))
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
            ViewData["CitizenId"] = new SelectList(_context.Citizen, "Id", "Id", ownerShip.CitizenId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "Id", "Id", ownerShip.VehicleId);
            return View(ownerShip);
        }

        // GET: OwnerShips/Delete/5
        //Gets the ownership for delete 
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerShip =  _context.OwnerShip
                .Include(o => o.Citizen)
                .Include(o => o.Vehicle)
                .FirstOrDefault(m => m.Id == id);
            if (ownerShip == null)
            {
                return NotFound();
            }

            return View(ownerShip);
        }

        // POST: OwnerShips/Delete/5
        //Deletes the ownership
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ownerShip = _context.OwnerShip.Find(id);
            _context.OwnerShip.Remove(ownerShip);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the ownership using a lamda.
        private bool OwnerShipExists(int id)
        {
            return _context.OwnerShip.Any(e => e.Id == id);
        }
    }
}
