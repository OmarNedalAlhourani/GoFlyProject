using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoFly.BL.Models.ContactPage;
using GoFly.BL.IRepositories;
using GoFly.EF.Data;

namespace GoFly.UI.Areas.Admin.Controllers.Contact
{
    [Area("Admin")]
    public class OurAddressesController : Controller
    {
        private readonly AppDbContext _context;
		public IBaseRepository<OurAddress> _ourAddressRepository;
		public OurAddressesController(AppDbContext context , IBaseRepository<OurAddress> ourAddressRepository)
        {
            _context = context;
			_ourAddressRepository = ourAddressRepository;
		}
		


		// GET: Admin/OurAddresses
		public async Task<IActionResult> Index()
        {
              return _context.OurAddresses != null ? 
                          View(await _context.OurAddresses.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.OurAddresses'  is null.");
        }






        // GET: Admin/OurAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OurAddresses == null)
            {
                return NotFound();
            }

            var ourAddress = await _context.OurAddresses
                .FirstOrDefaultAsync(m => m.OurAddressId == id);
            if (ourAddress == null)
            {
                return NotFound();
            }

            return View(ourAddress);
        }

        // GET: Admin/OurAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/OurAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OurAddressId,Description,Address,PhoneNumber,EmailAddress,Site,CreationDate,IsDleted")] OurAddress ourAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ourAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ourAddress);
        }

        // GET: Admin/OurAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OurAddresses == null)
            {
                return NotFound();
            }

            var ourAddress = await _context.OurAddresses.FindAsync(id);
            if (ourAddress == null)
            {
                return NotFound();
            }
            return View(ourAddress);
        }

        // POST: Admin/OurAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OurAddressId,Description,Address,PhoneNumber,EmailAddress,Site,UserName,UserEmail,UserMassage,CreationDate,IsDleted")] OurAddress ourAddress)
        {
            if (id != ourAddress.OurAddressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ourAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OurAddressExists(ourAddress.OurAddressId))
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
            return View(ourAddress);
        }

        // GET: Admin/OurAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OurAddresses == null)
            {
                return NotFound();
            }

            var ourAddress = await _context.OurAddresses
                .FirstOrDefaultAsync(m => m.OurAddressId == id);
            if (ourAddress == null)
            {
                return NotFound();
            }

            return View(ourAddress);
        }

        // POST: Admin/OurAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OurAddresses == null)
            {
                return Problem("Entity set 'AppDbContext.OurAddresses'  is null.");
            }
            var ourAddress = await _context.OurAddresses.FindAsync(id);
            if (ourAddress != null)
            {
                _context.OurAddresses.Remove(ourAddress);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OurAddressExists(int id)
        {
          return (_context.OurAddresses?.Any(e => e.OurAddressId == id)).GetValueOrDefault();
        }
    }
}
