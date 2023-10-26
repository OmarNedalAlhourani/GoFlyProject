using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoFly.BL.Models.BlogPage;
using GoFly.EF.Data;
using GoFly.BL.IRepositories;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using GoFly.BL.Models.HomePage;

namespace GoFly.UI.Areas.Admin.Controllers.Our
{
    [Area("Admin")]
    public class OurBlogsController : Controller
    {
        private readonly AppDbContext _context;

        public IBaseRepository<OurBlog> ourBlogRepository;
        private readonly IHostingEnvironment hosting;

        public OurBlogsController(AppDbContext context, IBaseRepository<OurBlog> _ourBlogRepository, IHostingEnvironment hosting)
        {
            _context = context;
            ourBlogRepository = _ourBlogRepository;
            this.hosting = hosting;
        }

        // GET: Admin/OurBlogs
        public async Task<IActionResult> Index()
        {
            return _context.OurBlogs != null ?
                        View(await _context.OurBlogs.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.OurBlogs'  is null.");
        }

        // GET: Admin/OurBlogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OurBlogs == null)
            {
                return NotFound();
            }

            var ourBlog = await _context.OurBlogs
                .FirstOrDefaultAsync(m => m.OurBlogId == id);
            if (ourBlog == null)
            {
                return NotFound();
            }

            return View(ourBlog);
        }

        // GET: Admin/OurBlogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/OurBlogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OurBlog ourBlog)
        {
            if (ModelState.IsValid)
            {

                if (ourBlog.Image != null)
                {
                    string ImageFolder = Path.Combine(hosting.WebRootPath, "images");
                    string imagepath = Path.Combine(ImageFolder, ourBlog.Image.FileName);
                    ourBlog.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
                    ourBlog.ImagePath = ourBlog.Image.FileName;

                }
                _context.Add(ourBlog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ourBlog);
        }

        // GET: Admin/OurBlogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OurBlogs == null)
            {
                return NotFound();
            }

            var ourBlog = await _context.OurBlogs.FindAsync(id);
            if (ourBlog == null)
            {
                return NotFound();
            }
            return View(ourBlog);
        }

        // POST: Admin/OurBlogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OurBlogId,Titel,Date,Description,ImagePath,CreationDate,IsDleted")] OurBlog ourBlog)
        {
            if (id != ourBlog.OurBlogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ourBlog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OurBlogExists(ourBlog.OurBlogId))
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
            return View(ourBlog);
        }

        // GET: Admin/OurBlogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OurBlogs == null)
            {
                return NotFound();
            }

            var ourBlog = await _context.OurBlogs
                .FirstOrDefaultAsync(m => m.OurBlogId == id);
            if (ourBlog == null)
            {
                return NotFound();
            }

            return View(ourBlog);
        }

        // POST: Admin/OurBlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OurBlogs == null)
            {
                return Problem("Entity set 'AppDbContext.OurBlogs'  is null.");
            }
            var ourBlog = await _context.OurBlogs.FindAsync(id);
            if (ourBlog != null)
            {
                _context.OurBlogs.Remove(ourBlog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OurBlogExists(int id)
        {
            return (_context.OurBlogs?.Any(e => e.OurBlogId == id)).GetValueOrDefault();
        }
    }
}
