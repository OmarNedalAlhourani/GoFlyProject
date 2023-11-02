using GoFly.BL.IRepositories;
using GoFly.BL.Models.ContactPage;
using GoFly.EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoFly.UI.Areas.Admin.Controllers.Contact
{
	public class MessageController : Controller
	{
		public IBaseRepository<Message> MessageRepository;
		public AppDbContext _db;
        public MessageController(IBaseRepository<Message> _MessageRepository,AppDbContext db)
        {
			MessageRepository = _MessageRepository;
			_db = db;
				
        }
        public IActionResult Index()
		{
			return View(MessageRepository.GetAll());
		}

		
	}
}
