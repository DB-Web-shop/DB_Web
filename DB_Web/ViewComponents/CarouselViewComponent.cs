using DB_Web.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DB_Web.ViewComponents
{
    public class CarouselViewComponent:ViewComponent
    {
        private readonly IConfigswebServices _configsweb;
        public CarouselViewComponent(IConfigswebServices configsweb)
        {
            _configsweb = configsweb;
        }
        public IViewComponentResult Invoke()
        {
            var config = _configsweb.GetConfigsweb();
            return View(config);
        }
    }
}
