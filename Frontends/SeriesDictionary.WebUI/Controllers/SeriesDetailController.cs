using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeriesDictionary.Persistence.Context;

namespace SeriesDictionary.WebUI.Controllers
{
    public class SeriesDetailController : Controller
    {
        private readonly DictionaryContext _context;

        public SeriesDetailController(DictionaryContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var show = _context.Show
                .Include(s => s.Episodes) // Bölümleri dahil et
                .FirstOrDefault(s => s.Id == id);

            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }
    }
}
