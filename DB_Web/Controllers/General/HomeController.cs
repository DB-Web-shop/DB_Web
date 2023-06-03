using DB_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using X.PagedList;

namespace DB_Web.Controllers.General
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbWebContext db = new DbWebContext();
        public List<Book> books;
        private int _msp=0;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            books = db.Books.AsNoTracking().OrderByDescending(x => x.Id).ToList();
        }

        public IActionResult Index()
        {
            return View(books);
        }

        public IActionResult Product(String masp)
        {
            int msp;
            if(int.TryParse(masp,out msp))
            {
                var sp = db.Books.Where(x => x.Id == msp).Include(x => x.IdtacgiaNavigation).Include(x => x.Category).Include(x => x.Status).FirstOrDefault();
                if(sp!=null)
                {
                    return View(sp);
                }
            }
            return RedirectToAction("","Error");

        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Collection(int? page, int? msp)
        {
            _msp = (msp == null)? _msp : msp.Value;
            int pageSize = 9;
            int pageNum = (page == null||page<=0)?1:page.Value;
            List<Book> lb = new List<Book>();
            String tenloai;
            if (_msp == 0)
            {
                lb = books;
                tenloai = "Tất cả sản phẩm";
            }
            else
            {
                lb = books.Where(x=>x.CategoryId ==_msp).ToList();
                tenloai = db.Categories.Where(x=>x.Id ==_msp).Single().Tenloai;
            }
            ViewData["msp"] = tenloai;
            PagedList<Book> list = new PagedList<Book>(lb, pageNum, pageSize);
            return View(list);
        }
        [HttpGet]
        public IEnumerable<Book>? FindBooks(string query)
        {
            if (query != null)
            {
                var result = db.Books.Where(x => x.Tensach.Contains(query)).ToList();
                if(result != null)
                    return result;
            }
            return null;
        }

    }
}