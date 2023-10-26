using GoFly.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoFly.ViewComponents.CarPage
{
    public class CarRentViewComponent : ViewComponent
    {
        public AppDbContext _db;

        public CarRentViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.CarRents.OrderByDescending(x => x.CreationDate));
        }
    }
}
