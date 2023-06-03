using Microsoft.AspNetCore.Mvc;

namespace DB_Web.Controllers.General
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Order()
        {
            return View();
        }
        [Route("~/account/order/detail/{id}")]
        public IActionResult Order_Detail()
        {
            return View();
        }
    }
}
