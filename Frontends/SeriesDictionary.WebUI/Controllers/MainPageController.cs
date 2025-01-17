using Microsoft.AspNetCore.Mvc;

namespace SeriesDictionary.WebUI.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
