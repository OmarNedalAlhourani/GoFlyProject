using GoFly.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoFly.UI.ViewComponents.vacation
{
    public class TouristSpotsViewComponent:ViewComponent
    {
        public AppDbContext _db;

        public TouristSpotsViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.TouristSpotes.OrderByDescending(x => x.CreationDate));
        }
    }
}
