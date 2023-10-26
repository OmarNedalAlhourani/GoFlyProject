using GoFly.BL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoFly.EF.Data;

namespace GoFly.UI.ViewComponents.Blog
{
    public class OurBlogViewComponent:ViewComponent
    {
        public AppDbContext _db;

        public OurBlogViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.OurBlogs.OrderByDescending(x => x.CreationDate));
        }
    }
}
