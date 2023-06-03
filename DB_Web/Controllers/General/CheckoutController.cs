using Microsoft.AspNetCore.Mvc;

namespace DB_Web.Controllers.General
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
