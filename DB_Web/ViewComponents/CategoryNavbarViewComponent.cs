using DB_Web.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DB_Web.ViewComponents
{
    public class CategoryNavbarViewComponent : ViewComponent
    {
        private readonly ICategoryServices _category;
        public CategoryNavbarViewComponent(ICategoryServices category)
        {
            _category = category;
        }
        public IViewComponentResult Invoke()
        {
            var category = _category.GetAllCategories().OrderBy(x => x.Id);
            return View(category);
        }
    }
}
