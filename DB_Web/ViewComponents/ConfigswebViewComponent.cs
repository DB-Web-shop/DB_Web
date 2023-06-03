using DB_Web.IServices;
using DB_Web.Models;
using Microsoft.AspNetCore.Mvc;
namespace DB_Web.ViewComponents
{
    public class ConfigswebViewComponent:ViewComponent
    {
        private readonly IConfigswebServices _configsweb;
        public ConfigswebViewComponent(IConfigswebServices configsweb)
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
