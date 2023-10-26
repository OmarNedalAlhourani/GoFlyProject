using GoFly.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoFly.UI.ViewComponents.Home
{
    public class BlogViewComponent : ViewComponent
    {
        public AppDbContext _db;

        public BlogViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.Blogs.OrderByDescending(x => x.CreationDate));
        }
    }
}
