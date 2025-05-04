using Microsoft.AspNetCore.Mvc;

namespace QRDER.Conrollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
