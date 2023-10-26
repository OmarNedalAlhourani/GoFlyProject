using GoFly.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoFly.UI.Models.ViewComponents.Flight
{
    public class TodayFlightViewComponent:ViewComponent
    {
        public AppDbContext _db;

        public TodayFlightViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.TodayFlights.OrderByDescending(x => x.CreationDate));
        }
    }
}
