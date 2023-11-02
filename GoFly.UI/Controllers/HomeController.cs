using GoFly.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GoFly.EF.Data;
using GoFly.BL.Models.ContactPage;
using Microsoft.EntityFrameworkCore;
using GoFly.BL.IRepositories;

namespace GoFly.UI.Controllers
{
    public class HomeController : Controller
	{
		
		private readonly ILogger<HomeController> _logger;

		private AppDbContext _db;
		public HomeController(ILogger<HomeController> logger, AppDbContext db)
		{
			_logger = logger;
			_db = db;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult IndexHotel()
		{
			return View();
		}
		public IActionResult IndexCar()
		{
			return View();
		}
		public IActionResult IndexVacation()
		{
			return View();
		}
		public IActionResult IndexContact()
		{
			return View();
		}
		
		public IActionResult IndexBlog()
		{
			return View();
		}
		public IActionResult IndexFlight()
		{
			return View();
		}


		public IActionResult MessageIndex()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateMessage([Bind("UserName,UserEmail,UserMessage")] Message message)
		{
			_db.Add(message);
			_db.SaveChanges();
			return RedirectToAction("Index","Message", new { area = "admin" });
		}


		public IActionResult Privacy()
		{
			return View();
		}
		
	


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}