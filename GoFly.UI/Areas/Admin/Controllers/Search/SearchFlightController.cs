using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoFly.BL.Models.Search;
using GoFly.EF.Data;

namespace GoFly.UI.Areas.Admin.Controllers.Search
{
    [Area("Admin")]
    public class SearchFlightController : Controller
    {
        private readonly AppDbContext _context;

        public SearchFlightController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SearchFlight
        public async Task<IActionResult> Index()
        {
              return _context.SearchFlights != null ? 
                          View(await _context.SearchFlights.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.SearchFlights'  is null.");
        }

        // GET: Admin/SearchFlight/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SearchFlights == null)
            {
                return NotFound();
            }

            var searchFlight = await _context.SearchFlights
                .FirstOrDefaultAsync(m => m.SearchFlightId == id);
            if (searchFlight == null)
            {
                return NotFound();
            }

            return View(searchFlight);
        }

        // GET: Admin/SearchFlight/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SearchFlight/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SearchFlightId,SearchFlightFrom,SearchFlightTo,Class,CheckIn,CheckOut,Adult,Children")] SearchFlight searchFlight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(searchFlight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(searchFlight);
        }

        // GET: Admin/SearchFlight/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SearchFlights == null)
            {
                return NotFound();
            }

            var searchFlight = await _context.SearchFlights.FindAsync(id);
            if (searchFlight == null)
            {
                return NotFound();
            }
            return View(searchFlight);
        }

        // POST: Admin/SearchFlight/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SearchFlightId,SearchFlightFrom,SearchFlightTo,Class,CheckIn,CheckOut,Adult,Children")] SearchFlight searchFlight)
        {
            if (id != searchFlight.SearchFlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(searchFlight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SearchFlightExists(searchFlight.SearchFlightId))
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
            return View(searchFlight);
        }

        // GET: Admin/SearchFlight/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SearchFlights == null)
            {
                return NotFound();
            }

            var searchFlight = await _context.SearchFlights
                .FirstOrDefaultAsync(m => m.SearchFlightId == id);
            if (searchFlight == null)
            {
                return NotFound();
            }

            return View(searchFlight);
        }

        // POST: Admin/SearchFlight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SearchFlights == null)
            {
                return Problem("Entity set 'AppDbContext.SearchFlights'  is null.");
            }
            var searchFlight = await _context.SearchFlights.FindAsync(id);
            if (searchFlight != null)
            {
                _context.SearchFlights.Remove(searchFlight);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SearchFlightExists(int id)
        {
          return (_context.SearchFlights?.Any(e => e.SearchFlightId == id)).GetValueOrDefault();
        }
    }
}
