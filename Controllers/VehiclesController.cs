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
    //Vehicles controller with permissions.
    [Authorize]
    public class VehiclesController : Controller
    {
        private readonly Vehicle_Ownership_MVCDataContext _context;

        public VehiclesController(Vehicle_Ownership_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        //Get  all vehicles 
        public IActionResult Index()
        {
            return View((from vehicle in _context.Vehicle select vehicle).ToList());
        }

        // GET: Vehicles/Details/5
        //Gets the vehicle details.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle =  _context.Vehicle
                .FirstOrDefault(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        //Returns the vehicle create form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds the vehicle 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,RegistrationNumber,RegisteredDate")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        //Gets the vehicle for delete
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = _context.Vehicle.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the vehicle.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,RegistrationNumber,RegisteredDate")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
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
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        //Gets the vehicle for delete using a lamda 
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle =  _context.Vehicle
                .FirstOrDefault(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        //Removes the vehicle 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var vehicle =  _context.Vehicle.Find(id);
            _context.Vehicle.Remove(vehicle);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks existance of the vehicle using a lamda
        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }
    }
}
