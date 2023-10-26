using GoFly.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoFly.UI.ViewComponents.Hotel
{
    public class TravelBookingViewComponent:ViewComponent
    {
        public AppDbContext _db;

        public TravelBookingViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.TravelBookings.OrderByDescending(x => x.CreationDate));
        }
    }
}
