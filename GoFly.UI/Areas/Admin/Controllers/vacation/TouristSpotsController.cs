using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoFly.BL.Models.HotelPage;
using GoFly.BL.Models.vacationPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using GoFly.EF.Data;

namespace GoFly.UI.Areas.Admin.Controllers.vacation
{
    [Area("Admin")]
    public class TouristSpotsController : Controller
    {
        private readonly AppDbContext _context;
		private readonly IHostingEnvironment hosting;

		public TouristSpotsController(AppDbContext context,IHostingEnvironment hosting)
        {
            _context = context;
			this.hosting = hosting;
		}

        // GET: Admin/TouristSpots
        public async Task<IActionResult> Index()
        {
              return _context.TouristSpotes != null ? 
                          View(await _context.TouristSpotes.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.TouristSpotes'  is null.");
        }

        // GET: Admin/TouristSpots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TouristSpotes == null)
            {
                return NotFound();
            }

            var touristSpots = await _context.TouristSpotes
                .FirstOrDefaultAsync(m => m.TouristSpotsId == id);
            if (touristSpots == null)
            {
                return NotFound();
            }

            return View(touristSpots);
        }

        // GET: Admin/TouristSpots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TouristSpots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( TouristSpots touristSpots)
        {
            if (ModelState.IsValid)
            {
				if (touristSpots.Image != null)
				{
					string ImageFolder = Path.Combine(hosting.WebRootPath, "images");
					string imagepath = Path.Combine(ImageFolder, touristSpots.Image.FileName);
					touristSpots.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
					touristSpots.ImagePath = touristSpots.Image.FileName;

				}
				_context.Add(touristSpots);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(touristSpots);
        }

        // GET: Admin/TouristSpots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TouristSpotes == null)
            {
                return NotFound();
            }

            var touristSpots = await _context.TouristSpotes.FindAsync(id);
            if (touristSpots == null)
            {
                return NotFound();
            }
            return View(touristSpots);
        }

        // POST: Admin/TouristSpots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TouristSpotsId,TouristSpotsTitel,TouristSpotsDescription,Prise,Image,CreationDate,IsDleted")] TouristSpots touristSpots)
        {
            if (id != touristSpots.TouristSpotsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(touristSpots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TouristSpotsExists(touristSpots.TouristSpotsId))
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
            return View(touristSpots);
        }

        // GET: Admin/TouristSpots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TouristSpotes == null)
            {
                return NotFound();
            }

            var touristSpots = await _context.TouristSpotes
                .FirstOrDefaultAsync(m => m.TouristSpotsId == id);
            if (touristSpots == null)
            {
                return NotFound();
            }

            return View(touristSpots);
        }

        // POST: Admin/TouristSpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TouristSpotes == null)
            {
                return Problem("Entity set 'AppDbContext.TouristSpotes'  is null.");
            }
            var touristSpots = await _context.TouristSpotes.FindAsync(id);
            if (touristSpots != null)
            {
                _context.TouristSpotes.Remove(touristSpots);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TouristSpotsExists(int id)
        {
          return (_context.TouristSpotes?.Any(e => e.TouristSpotsId == id)).GetValueOrDefault();
        }
    }
}
