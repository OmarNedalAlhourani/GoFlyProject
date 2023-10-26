using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoFly.BL.Models.FlightsPage;
using GoFly.EF.Data;

namespace GoFly.UI.Areas.Admin.Controllers.Flight
{
    [Area("Admin")]
    public class TodayFlightsController : Controller
    {
        private readonly AppDbContext _context;

        public TodayFlightsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TodayFlights
        public async Task<IActionResult> Index()
        {
              return _context.TodayFlights != null ? 
                          View(await _context.TodayFlights.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.TodayFlights'  is null.");
        }

        // GET: Admin/TodayFlights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TodayFlights == null)
            {
                return NotFound();
            }

            var todayFlight = await _context.TodayFlights
                .FirstOrDefaultAsync(m => m.TodayFlightId == id);
            if (todayFlight == null)
            {
                return NotFound();
            }

            return View(todayFlight);
        }

        // GET: Admin/TodayFlights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TodayFlights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TodayFlightId,Titel,Description,AirLine,Location,Date,Prise,CreationDate,IsDleted")] TodayFlight todayFlight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todayFlight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todayFlight);
        }

        // GET: Admin/TodayFlights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TodayFlights == null)
            {
                return NotFound();
            }

            var todayFlight = await _context.TodayFlights.FindAsync(id);
            if (todayFlight == null)
            {
                return NotFound();
            }
            return View(todayFlight);
        }

        // POST: Admin/TodayFlights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TodayFlightId,Titel,Description,AirLine,Location,Date,Prise,CreationDate,IsDleted")] TodayFlight todayFlight)
        {
            if (id != todayFlight.TodayFlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todayFlight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodayFlightExists(todayFlight.TodayFlightId))
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
            return View(todayFlight);
        }

        // GET: Admin/TodayFlights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TodayFlights == null)
            {
                return NotFound();
            }

            var todayFlight = await _context.TodayFlights
                .FirstOrDefaultAsync(m => m.TodayFlightId == id);
            if (todayFlight == null)
            {
                return NotFound();
            }

            return View(todayFlight);
        }

        // POST: Admin/TodayFlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TodayFlights == null)
            {
                return Problem("Entity set 'AppDbContext.TodayFlights'  is null.");
            }
            var todayFlight = await _context.TodayFlights.FindAsync(id);
            if (todayFlight != null)
            {
                _context.TodayFlights.Remove(todayFlight);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodayFlightExists(int id)
        {
          return (_context.TodayFlights?.Any(e => e.TodayFlightId == id)).GetValueOrDefault();
        }
    }
}
