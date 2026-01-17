using Microsoft.AspNetCore.Mvc;


namespace SwimmingClass.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
