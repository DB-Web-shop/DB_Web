using DB_Web.IServices;
using DB_Web.Models;
using Microsoft.AspNetCore.Mvc;
namespace DB_Web.ViewComponents
{
    public class CategoryMenuViewComponent: ViewComponent
    {
        private readonly ICategoryServices _category;
        public CategoryMenuViewComponent(ICategoryServices category)
        {
            _category = category;
        }
        public IViewComponentResult Invoke()
        {
            var category = _category.GetAllCategories().OrderBy(x=>x.Id);
            return View(category);
        }
    }
}
