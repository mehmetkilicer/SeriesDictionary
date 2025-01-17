using Microsoft.AspNetCore.Mvc;

namespace SeriesDictionary.WebUI.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
