using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            var info = new ContactInfo()
            {
                Email = "teymuri.alireza98@gmail.com",
                Telegram = "@teymuri_alireza",
                Location = "ایران، تهران"
            };
            return View(info);
        }
    }
}
