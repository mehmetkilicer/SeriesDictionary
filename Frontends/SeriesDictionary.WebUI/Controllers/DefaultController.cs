using Microsoft.AspNetCore.Mvc;

namespace SeriesDictionary.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
