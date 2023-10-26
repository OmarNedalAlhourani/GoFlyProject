using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoFly.BL.Models.FlightsPage;
using GoFly.EF.Data;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace GoFly.UI.Areas.Admin.Controllers.Flight
{
    [Area("Admin")]
    public class DealsController : Controller
    {
        private readonly AppDbContext _context;
		private readonly IHostingEnvironment hosting;

		public DealsController(AppDbContext context ,IHostingEnvironment hosting)
        {
            _context = context;
			this.hosting = hosting;
		}

        // GET: Admin/Deals
        public async Task<IActionResult> Index()
        {
              return _context.Deals != null ? 
                          View(await _context.Deals.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Deals'  is null.");
        }

        // GET: Admin/Deals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Deals == null)
            {
                return NotFound();
            }

            var deal = await _context.Deals
                .FirstOrDefaultAsync(m => m.DealId == id);
            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // GET: Admin/Deals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Deals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Deal deal)
        {
            if (ModelState.IsValid)
            {

				if (deal.Image != null)
				{
					string ImageFolder = Path.Combine(hosting.WebRootPath, "images");
					string imagepath = Path.Combine(ImageFolder, deal.Image.FileName);
					deal.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
					deal.ImagePath = deal.Image.FileName;

				}
				_context.Add(deal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deal);
        }

        // GET: Admin/Deals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Deals == null)
            {
                return NotFound();
            }

            var deal = await _context.Deals.FindAsync(id);
            if (deal == null)
            {
                return NotFound();
            }
            return View(deal);
        }

        // POST: Admin/Deals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DealId,DealName,TitelDescription,DealDescription,DealPrise,ImagePath,CreationDate,IsDleted")] Deal deal)
        {
            if (id != deal.DealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealExists(deal.DealId))
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
            return View(deal);
        }

        // GET: Admin/Deals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Deals == null)
            {
                return NotFound();
            }

            var deal = await _context.Deals
                .FirstOrDefaultAsync(m => m.DealId == id);
            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // POST: Admin/Deals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Deals == null)
            {
                return Problem("Entity set 'AppDbContext.Deals'  is null.");
            }
            var deal = await _context.Deals.FindAsync(id);
            if (deal != null)
            {
                _context.Deals.Remove(deal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealExists(int id)
        {
          return (_context.Deals?.Any(e => e.DealId == id)).GetValueOrDefault();
        }
    }
}
