using GoFly.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoFly.UI.Models.ViewComponents.Flight
{
	public class DealViewComponent:ViewComponent
	{
		public AppDbContext _db;

		public DealViewComponent(AppDbContext db)
		{
			_db = db;
		}
		public IViewComponentResult Invoke()
		{
			return View(_db.Deals.OrderByDescending(x => x.CreationDate));
		}
	}
}
