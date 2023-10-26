using GoFly.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoFly.UI.ViewComponents.Home
{
    public class PopularDestinationViewComponent : ViewComponent
    {
        public AppDbContext _db;

        public PopularDestinationViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.PopularDestinations.OrderByDescending(x => x.CreationDate));
        }
    }
}
