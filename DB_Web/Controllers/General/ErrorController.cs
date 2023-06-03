using Microsoft.AspNetCore.Mvc;

namespace DB_Web.Controllers.General
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
