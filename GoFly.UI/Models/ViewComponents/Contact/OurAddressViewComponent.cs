using GoFly.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoFly.UI.ViewComponents.Contact
{
    public class OurAddressViewComponent : ViewComponent
	{
		public AppDbContext _db;

		public OurAddressViewComponent(AppDbContext db)
		{
			_db = db;
		}
		public IViewComponentResult Invoke()
		{
			return View(_db.OurAddresses.OrderByDescending(x => x.CreationDate));
		}
	}
}
