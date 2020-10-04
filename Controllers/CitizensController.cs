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
    //Authorised Citizens Controller.
    [Authorize]
    public class CitizensController : Controller
    {
        private readonly Vehicle_Ownership_MVCDataContext _context;

        public CitizensController(Vehicle_Ownership_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Citizens
        //Get all citizens
        public IActionResult Index()
        {
            return View( _context.Citizen.ToList());
        }

        // GET: Citizens/Details/5
        //Gets the details of a citizen using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizen =  _context.Citizen
                .FirstOrDefault(m => m.Id == id);
            if (citizen == null)
            {
                return NotFound();
            }

            return View(citizen);
        }

        // GET: Citizens/Create
        //Gets the create citizens form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Citizens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds a citizen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Address")] Citizen citizen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citizen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(citizen);
        }

        // GET: Citizens/Edit/5
        //Gets the citizen ofr update
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizen =  _context.Citizen.Find(id);
            if (citizen == null)
            {
                return NotFound();
            }
            return View(citizen);
        }

        // POST: Citizens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the citizen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Address")] Citizen citizen)
        {
            if (id != citizen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citizen);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitizenExists(citizen.Id))
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
            return View(citizen);
        }

        // GET: Citizens/Delete/5
        //Gets the citizen for delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizen = _context.Citizen
                .FirstOrDefault(m => m.Id == id);
            if (citizen == null)
            {
                return NotFound();
            }

            return View(citizen);
        }

        // POST: Citizens/Delete/5
        //Deletes the citizen. uses a linq query to select.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var citizen = (from citizens in _context.Citizen
                           where citizens.Id == id
                           select citizens).FirstOrDefault();
            _context.Citizen.Remove(citizen);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks for existance using a  lamda 
        private bool CitizenExists(int id)
        {
            return _context.Citizen.Any(e => e.Id == id);
        }
    }
}
