using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers
{
    public class CoffeeShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View(); 
        }
    }
}
