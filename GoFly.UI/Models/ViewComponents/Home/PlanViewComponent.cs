using GoFly.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoFly.UI.ViewComponents.Home
{
    public class PlanViewComponent : ViewComponent
    {
        public AppDbContext _db;

        public PlanViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.Plans.OrderByDescending(x => x.CreationDate));
        }
    }
}
