using GoFly.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoFly.UI.Models.ViewComponents.Contact
{
    public class MessageViewComponent : ViewComponent
    {
        public AppDbContext _db;

        public MessageViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.Messages.OrderByDescending(x => x.CreationDate));
        }
    }
}
