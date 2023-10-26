using Microsoft.AspNetCore.Mvc;

namespace GoFly.UI.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
