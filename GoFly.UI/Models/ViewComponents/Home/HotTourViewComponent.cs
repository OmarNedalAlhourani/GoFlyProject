using GoFly.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoFly.UI.ViewComponents.Home
{
    public class HotTourViewComponent : ViewComponent
    {
        public AppDbContext _db;

        public HotTourViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.HotTours.OrderByDescending(x => x.CreationDate));
        }
    }
}
