using GoFly.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoFly.UI.ViewComponents.Hotel
{
    public class HostelDestinationViewComponent:ViewComponent
    {
        public AppDbContext _db;

        public HostelDestinationViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.HostelDestinations.OrderByDescending(x => x.CreationDate));
        }
    }
}
