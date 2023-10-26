using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoFly.BL.Models.HomePage;
using GoFly.EF.Data;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using GoFly.BL.Models.FlightsPage;

namespace GoFly.UI.Areas.Admin.Controllers.Home
{
    [Area("Admin")]
    public class HotTourController : Controller
    {
        private readonly AppDbContext _context;
		private readonly IHostingEnvironment hosting;

		public HotTourController(AppDbContext context,IHostingEnvironment hosting)
        {
            _context = context;
			this.hosting = hosting;
		}

        // GET: Admin/HotTour
        public async Task<IActionResult> Index()
        {
              return _context.HotTours != null ? 
                          View(await _context.HotTours.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.HotTours'  is null.");
        }

        // GET: Admin/HotTour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HotTours == null)
            {
                return NotFound();
            }

            var hotTour = await _context.HotTours
                .FirstOrDefaultAsync(m => m.HotTourId == id);
            if (hotTour == null)
            {
                return NotFound();
            }

            return View(hotTour);
        }

        // GET: Admin/HotTour/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HotTour/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( HotTour hotTour)
        {
            if (ModelState.IsValid)
            {
                if (hotTour.Image !=null)
                {
					string ImageFolder = Path.Combine(hosting.WebRootPath, "images");
					string imagepath = Path.Combine(ImageFolder, hotTour.Image.FileName);
					hotTour.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
					hotTour.ImagePath = hotTour.Image.FileName;
				}

                _context.Add(hotTour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotTour);
        }

        // GET: Admin/HotTour/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HotTours == null)
            {
                return NotFound();
            }

            var hotTour = await _context.HotTours.FindAsync(id);
            if (hotTour == null)
            {
                return NotFound();
            }
            return View(hotTour);
        }

        // POST: Admin/HotTour/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotTourId,HotTourName,TitelDescription,HotTourDescription,HotTourPrise,ImagePath,CreationDate,IsDleted")] HotTour hotTour)
        {
            if (id != hotTour.HotTourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotTour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotTourExists(hotTour.HotTourId))
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
            return View(hotTour);
        }

        // GET: Admin/HotTour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HotTours == null)
            {
                return NotFound();
            }

            var hotTour = await _context.HotTours
                .FirstOrDefaultAsync(m => m.HotTourId == id);
            if (hotTour == null)
            {
                return NotFound();
            }

            return View(hotTour);
        }

        // POST: Admin/HotTour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HotTours == null)
            {
                return Problem("Entity set 'AppDbContext.HotTours'  is null.");
            }
            var hotTour = await _context.HotTours.FindAsync(id);
            if (hotTour != null)
            {
                _context.HotTours.Remove(hotTour);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotTourExists(int id)
        {
          return (_context.HotTours?.Any(e => e.HotTourId == id)).GetValueOrDefault();
        }
    }
}
