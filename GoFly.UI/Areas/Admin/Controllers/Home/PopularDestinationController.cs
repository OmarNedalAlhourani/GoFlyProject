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

namespace GoFly.UI.Areas.Admin.Controllers.Home
{
    [Area("Admin")]
    public class PopularDestinationController : Controller
    {
        private readonly AppDbContext _context;
		private readonly IHostingEnvironment hosting;

		public PopularDestinationController(AppDbContext context,IHostingEnvironment hosting)
        {
            _context = context;
			this.hosting = hosting;
		}

        // GET: Admin/PopularDestination
        public async Task<IActionResult> Index()
        {
              return _context.PopularDestinations != null ? 
                          View(await _context.PopularDestinations.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.PopularDestinations'  is null.");
        }

        // GET: Admin/PopularDestination/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PopularDestinations == null)
            {
                return NotFound();
            }

            var popularDestination = await _context.PopularDestinations
                .FirstOrDefaultAsync(m => m.PopularDestinationId == id);
            if (popularDestination == null)
            {
                return NotFound();
            }

            return View(popularDestination);
        }

        // GET: Admin/PopularDestination/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PopularDestination/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PopularDestination popularDestination)
        {
            if (ModelState.IsValid)
            {
				if (popularDestination.Image != null)
				{
					string ImageFolder = Path.Combine(hosting.WebRootPath, "images");
					string imagepath = Path.Combine(ImageFolder, popularDestination.Image.FileName);
					popularDestination.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
					popularDestination.ImagePath = popularDestination.Image.FileName;
				}


				_context.Add(popularDestination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(popularDestination);
        }

        // GET: Admin/PopularDestination/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PopularDestinations == null)
            {
                return NotFound();
            }

            var popularDestination = await _context.PopularDestinations.FindAsync(id);
            if (popularDestination == null)
            {
                return NotFound();
            }
            return View(popularDestination);
        }

        // POST: Admin/PopularDestination/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PopularDestinationId,PopularDestinationName,ImagePath,CreationDate,IsDleted")] PopularDestination popularDestination)
        {
            if (id != popularDestination.PopularDestinationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(popularDestination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PopularDestinationExists(popularDestination.PopularDestinationId))
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
            return View(popularDestination);
        }

        // GET: Admin/PopularDestination/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PopularDestinations == null)
            {
                return NotFound();
            }

            var popularDestination = await _context.PopularDestinations
                .FirstOrDefaultAsync(m => m.PopularDestinationId == id);
            if (popularDestination == null)
            {
                return NotFound();
            }

            return View(popularDestination);
        }

        // POST: Admin/PopularDestination/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PopularDestinations == null)
            {
                return Problem("Entity set 'AppDbContext.PopularDestinations'  is null.");
            }
            var popularDestination = await _context.PopularDestinations.FindAsync(id);
            if (popularDestination != null)
            {
                _context.PopularDestinations.Remove(popularDestination);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PopularDestinationExists(int id)
        {
          return (_context.PopularDestinations?.Any(e => e.PopularDestinationId == id)).GetValueOrDefault();
        }
    }
}
