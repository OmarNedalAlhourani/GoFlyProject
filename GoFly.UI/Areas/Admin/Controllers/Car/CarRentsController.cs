using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoFly.BL.Models.CarPage;
using GoFly.BL.Models.HomePage;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using GoFly.EF.Data;

namespace GoFly.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarRentsController : Controller
    {
        private readonly AppDbContext _context;
        public  IHostingEnvironment hosting;

        public CarRentsController(AppDbContext context,IHostingEnvironment hosting)
        {
            _context = context;
            this.hosting = hosting;
        }

        // GET: Admin/CarRents
        public async Task<IActionResult> Index()
        {
              return _context.CarRents != null ? 
                          View(await _context.CarRents.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.CarRents'  is null.");
        }

        // GET: Admin/CarRents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarRents == null)
            {
                return NotFound();
            }

            var carRent = await _context.CarRents
                .FirstOrDefaultAsync(m => m.CarRentId == id);
            if (carRent == null)
            {
                return NotFound();
            }

            return View(carRent);
        }

        // GET: Admin/CarRents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CarRents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CarRent carRent)
        {
            if (ModelState.IsValid)
            {
               
                    if (carRent.Image != null)
                    {
                        string ImageFolder = Path.Combine(hosting.WebRootPath,"images");
                        string imagepath = Path.Combine(ImageFolder, carRent.Image.FileName);
                    carRent.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
                    carRent.ImagePath = carRent.Image.FileName;

                    }
                    _context.Add(carRent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carRent);
        }

        // GET: Admin/CarRents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarRents == null)
            {
                return NotFound();
            }

            var carRent = await _context.CarRents.FindAsync(id);
            if (carRent == null)
            {
                return NotFound();
            }
            return View(carRent);
        }

        // POST: Admin/CarRents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarRentId,CarRentTitel,PriseDay,PriseWeek,PriseMonth,Tax,Image,CreationDate,IsDleted")] CarRent carRent)
        {
            if (id != carRent.CarRentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carRent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarRentExists(carRent.CarRentId))
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
            return View(carRent);
        }

        // GET: Admin/CarRents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarRents == null)
            {
                return NotFound();
            }

            var carRent = await _context.CarRents
                .FirstOrDefaultAsync(m => m.CarRentId == id);
            if (carRent == null)
            {
                return NotFound();
            }

            return View(carRent);
        }

        // POST: Admin/CarRents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarRents == null)
            {
                return Problem("Entity set 'AppDbContext.CarRents'  is null.");
            }
            var carRent = await _context.CarRents.FindAsync(id);
            if (carRent != null)
            {
                _context.CarRents.Remove(carRent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarRentExists(int id)
        {
          return (_context.CarRents?.Any(e => e.CarRentId == id)).GetValueOrDefault();
        }
    }
}
