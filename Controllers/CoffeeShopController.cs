using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models.DatabaseContext;

namespace MyPortfolio.Controllers
{
    public class CoffeeShopController : Controller
    {
        private readonly MyDbContext _context;
        public CoffeeShopController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Product(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var item = _context.CoffeeProducts.FirstOrDefault(a => a.Id == id);
            if (item == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }
    }
}
