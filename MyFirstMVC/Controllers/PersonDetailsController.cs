using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstMVC.Data;
using MyFirstMVC.Models.Entities;

namespace MyFirstMVC.Controllers
{
    public class PersonDetailsController : Controller
    {
        private readonly FirstContext _context;

        public PersonDetailsController(FirstContext context)
        {
            _context = context;
        }

        // GET: PersonDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.PersonDetails.ToListAsync());
        }

        // GET: PersonDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonDetails == null)
            {
                return NotFound();
            }

            var personDetails = await _context.PersonDetails
                .FirstOrDefaultAsync(m => m.DetailsID == id);
            if (personDetails == null)
            {
                return NotFound();
            }

            return View(personDetails);
        }

        // GET: PersonDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetailsID,Age,Description,WorkPosition,PictureURl,Education,EducationLevel")] PersonDetails personDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personDetails);
        }

        // GET: PersonDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonDetails == null)
            {
                return NotFound();
            }

            var personDetails = await _context.PersonDetails.FindAsync(id);
            if (personDetails == null)
            {
                return NotFound();
            }
            return View(personDetails);
        }

        // POST: PersonDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetailsID,Age,Description,WorkPosition,PictureURl,Education,EducationLevel")] PersonDetails personDetails)
        {
            if (id != personDetails.DetailsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonDetailsExists(personDetails.DetailsID))
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
            return View(personDetails);
        }

        // GET: PersonDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonDetails == null)
            {
                return NotFound();
            }

            var personDetails = await _context.PersonDetails
                .FirstOrDefaultAsync(m => m.DetailsID == id);
            if (personDetails == null)
            {
                return NotFound();
            }

            return View(personDetails);
        }

        // POST: PersonDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonDetails == null)
            {
                return Problem("Entity set 'FirstContext.PersonDetails'  is null.");
            }
            var personDetails = await _context.PersonDetails.FindAsync(id);
            if (personDetails != null)
            {
                _context.PersonDetails.Remove(personDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonDetailsExists(int id)
        {
          return _context.PersonDetails.Any(e => e.DetailsID == id);
        }
    }
}
