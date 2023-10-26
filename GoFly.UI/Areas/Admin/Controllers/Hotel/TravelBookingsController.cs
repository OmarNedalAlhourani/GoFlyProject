using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoFly.BL.Models.HotelPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using GoFly.EF.Data;

namespace GoFly.UI.Areas.Admin.Controllers.Hotel
{
    [Area("Admin")]
    public class TravelBookingsController : Controller
    {
        private readonly AppDbContext _context;
		private readonly IHostingEnvironment hosting;

		public TravelBookingsController(AppDbContext context,IHostingEnvironment hosting)
        {
            _context = context;
			this.hosting = hosting;
		}

        // GET: Admin/TravelBookings
        public async Task<IActionResult> Index()
        {
            return _context.TravelBookings != null ?
                        View(await _context.TravelBookings.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.TravelBookings'  is null.");
        }

        // GET: Admin/TravelBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TravelBookings == null)
            {
                return NotFound();
            }

            var travelBooking = await _context.TravelBookings
                .FirstOrDefaultAsync(m => m.TravelBookingId == id);
            if (travelBooking == null)
            {
                return NotFound();
            }

            return View(travelBooking);
        }

        // GET: Admin/TravelBookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TravelBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( TravelBooking travelBooking)
        {
            if (ModelState.IsValid)
            {
                if (travelBooking.Image !=null)
                {
					string ImageFolder = Path.Combine(hosting.WebRootPath, "images");
					string imagepath = Path.Combine(ImageFolder, travelBooking.Image.FileName);
					travelBooking.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
					travelBooking.ImagePath = travelBooking.Image.FileName;

				}

				_context.Add(travelBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelBooking);
        }

        // GET: Admin/TravelBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TravelBookings == null)
            {
                return NotFound();
            }

            var travelBooking = await _context.TravelBookings.FindAsync(id);
            if (travelBooking == null)
            {
                return NotFound();
            }
            return View(travelBooking);
        }

        // POST: Admin/TravelBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TravelBookingId,TravelBookingDescription,Image,CreationDate,IsDleted")] TravelBooking travelBooking)
        {
            if (id != travelBooking.TravelBookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelBookingExists(travelBooking.TravelBookingId))
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
            return View(travelBooking);
        }

        // GET: Admin/TravelBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TravelBookings == null)
            {
                return NotFound();
            }

            var travelBooking = await _context.TravelBookings
                .FirstOrDefaultAsync(m => m.TravelBookingId == id);
            if (travelBooking == null)
            {
                return NotFound();
            }

            return View(travelBooking);
        }

        // POST: Admin/TravelBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TravelBookings == null)
            {
                return Problem("Entity set 'AppDbContext.TravelBookings'  is null.");
            }
            var travelBooking = await _context.TravelBookings.FindAsync(id);
            if (travelBooking != null)
            {
                _context.TravelBookings.Remove(travelBooking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelBookingExists(int id)
        {
            return (_context.TravelBookings?.Any(e => e.TravelBookingId == id)).GetValueOrDefault();
        }
    }
}
