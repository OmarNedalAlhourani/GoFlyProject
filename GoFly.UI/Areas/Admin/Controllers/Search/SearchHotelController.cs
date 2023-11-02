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
    public class SearchHotelController : Controller
    {
        private readonly AppDbContext _context;

        public SearchHotelController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SearchHotel
        public async Task<IActionResult> Index()
        {
              return _context.SearchHotels != null ? 
                          View(await _context.SearchHotels.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.SearchHotels'  is null.");
        }

        // GET: Admin/SearchHotel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SearchHotels == null)
            {
                return NotFound();
            }

            var searchHotel = await _context.SearchHotels
                .FirstOrDefaultAsync(m => m.SearchHotelId == id);
            if (searchHotel == null)
            {
                return NotFound();
            }

            return View(searchHotel);
        }

        // GET: Admin/SearchHotel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SearchHotel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SearchHotelId,City,Room,CheckIn,CheckOut,Adult,Children")] SearchHotel searchHotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(searchHotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(searchHotel);
        }

        // GET: Admin/SearchHotel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SearchHotels == null)
            {
                return NotFound();
            }

            var searchHotel = await _context.SearchHotels.FindAsync(id);
            if (searchHotel == null)
            {
                return NotFound();
            }
            return View(searchHotel);
        }

        // POST: Admin/SearchHotel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SearchHotelId,City,Room,CheckIn,CheckOut,Adult,Children")] SearchHotel searchHotel)
        {
            if (id != searchHotel.SearchHotelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(searchHotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SearchHotelExists(searchHotel.SearchHotelId))
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
            return View(searchHotel);
        }

        // GET: Admin/SearchHotel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SearchHotels == null)
            {
                return NotFound();
            }

            var searchHotel = await _context.SearchHotels
                .FirstOrDefaultAsync(m => m.SearchHotelId == id);
            if (searchHotel == null)
            {
                return NotFound();
            }

            return View(searchHotel);
        }

        // POST: Admin/SearchHotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SearchHotels == null)
            {
                return Problem("Entity set 'AppDbContext.SearchHotels'  is null.");
            }
            var searchHotel = await _context.SearchHotels.FindAsync(id);
            if (searchHotel != null)
            {
                _context.SearchHotels.Remove(searchHotel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SearchHotelExists(int id)
        {
          return (_context.SearchHotels?.Any(e => e.SearchHotelId == id)).GetValueOrDefault();
        }
    }
}
