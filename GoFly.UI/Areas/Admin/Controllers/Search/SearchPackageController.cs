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
    public class SearchPackageController : Controller
    {
        private readonly AppDbContext _context;

        public SearchPackageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SearchPackage
        public async Task<IActionResult> Index()
        {
              return _context.SearchPackages != null ? 
                          View(await _context.SearchPackages.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.SearchPackages'  is null.");
        }

        // GET: Admin/SearchPackage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SearchPackages == null)
            {
                return NotFound();
            }

            var searchPackage = await _context.SearchPackages
                .FirstOrDefaultAsync(m => m.SearchPackageId == id);
            if (searchPackage == null)
            {
                return NotFound();
            }

            return View(searchPackage);
        }

        // GET: Admin/SearchPackage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SearchPackage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SearchPackageId,Destination,City,Room,CheckIn,CheckOut,Adult,Children")] SearchPackage searchPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(searchPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(searchPackage);
        }

        // GET: Admin/SearchPackage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SearchPackages == null)
            {
                return NotFound();
            }

            var searchPackage = await _context.SearchPackages.FindAsync(id);
            if (searchPackage == null)
            {
                return NotFound();
            }
            return View(searchPackage);
        }

        // POST: Admin/SearchPackage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SearchPackageId,Destination,City,Room,CheckIn,CheckOut,Adult,Children")] SearchPackage searchPackage)
        {
            if (id != searchPackage.SearchPackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(searchPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SearchPackageExists(searchPackage.SearchPackageId))
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
            return View(searchPackage);
        }

        // GET: Admin/SearchPackage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SearchPackages == null)
            {
                return NotFound();
            }

            var searchPackage = await _context.SearchPackages
                .FirstOrDefaultAsync(m => m.SearchPackageId == id);
            if (searchPackage == null)
            {
                return NotFound();
            }

            return View(searchPackage);
        }

        // POST: Admin/SearchPackage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SearchPackages == null)
            {
                return Problem("Entity set 'AppDbContext.SearchPackages'  is null.");
            }
            var searchPackage = await _context.SearchPackages.FindAsync(id);
            if (searchPackage != null)
            {
                _context.SearchPackages.Remove(searchPackage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SearchPackageExists(int id)
        {
          return (_context.SearchPackages?.Any(e => e.SearchPackageId == id)).GetValueOrDefault();
        }
    }
}
