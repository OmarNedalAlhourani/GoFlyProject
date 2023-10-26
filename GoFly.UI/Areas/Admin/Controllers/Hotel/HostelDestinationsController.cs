using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoFly.BL.Models.CarPage;
using GoFly.BL.Models.HotelPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using GoFly.EF.Data;

namespace GoFly.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HostelDestinationsController : Controller
    {
        private readonly AppDbContext _context;
		private readonly IHostingEnvironment hosting;

		public HostelDestinationsController(AppDbContext context, IHostingEnvironment hosting)
        {
            _context = context;
			this.hosting = hosting;
		}

        // GET: Admin/HostelDestinations
        public async Task<IActionResult> Index()
        {
              return _context.HostelDestinations != null ? 
                          View(await _context.HostelDestinations.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.HostelDestinations'  is null.");
        }

        // GET: Admin/HostelDestinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HostelDestinations == null)
            {
                return NotFound();
            }

            var hostelDestination = await _context.HostelDestinations
                .FirstOrDefaultAsync(m => m.HostelDestinationId == id);
            if (hostelDestination == null)
            {
                return NotFound();
            }

            return View(hostelDestination);
        }

        // GET: Admin/HostelDestinations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HostelDestinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HostelDestination hostelDestination)
        {
            if (ModelState.IsValid)
            {
				if (hostelDestination.Image != null)
				{
					string ImageFolder = Path.Combine(hosting.WebRootPath, "images");
					string imagepath = Path.Combine(ImageFolder, hostelDestination.Image.FileName);
					hostelDestination.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
					hostelDestination.ImagePath = hostelDestination.Image.FileName;

				}
				_context.Add(hostelDestination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hostelDestination);
        }

        // GET: Admin/HostelDestinations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HostelDestinations == null)
            {
                return NotFound();
            }

            var hostelDestination = await _context.HostelDestinations.FindAsync(id);
            if (hostelDestination == null)
            {
                return NotFound();
            }
            return View(hostelDestination);
        }

        // POST: Admin/HostelDestinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HostelDestinationId,HostelDestinationName,TitelDescription,HostelDestinationDescription,HostelDestinationPrise,Image,CreationDate,IsDleted")] HostelDestination hostelDestination)
        {
            if (id != hostelDestination.HostelDestinationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hostelDestination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostelDestinationExists(hostelDestination.HostelDestinationId))
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
            return View(hostelDestination);
        }

        // GET: Admin/HostelDestinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HostelDestinations == null)
            {
                return NotFound();
            }

            var hostelDestination = await _context.HostelDestinations
                .FirstOrDefaultAsync(m => m.HostelDestinationId == id);
            if (hostelDestination == null)
            {
                return NotFound();
            }

            return View(hostelDestination);
        }

        // POST: Admin/HostelDestinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HostelDestinations == null)
            {
                return Problem("Entity set 'AppDbContext.HostelDestinations'  is null.");
            }
            var hostelDestination = await _context.HostelDestinations.FindAsync(id);
            if (hostelDestination != null)
            {
                _context.HostelDestinations.Remove(hostelDestination);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HostelDestinationExists(int id)
        {
          return (_context.HostelDestinations?.Any(e => e.HostelDestinationId == id)).GetValueOrDefault();
        }
    }
}
