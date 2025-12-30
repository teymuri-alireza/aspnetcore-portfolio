using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models.DatabaseContext;
using MyPortfolio.Models.Entities;

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
        public async Task<IActionResult> Products()
        {
            var items = await _context.CoffeeProducts.ToListAsync();
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Type")] Coffee coffee, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
                return View(coffee);

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/images/CoffeeShop/uploads"
                );

                Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                coffee.ImagePath = "/images/CoffeeShop/uploads/" + fileName;
            }

            _context.CoffeeProducts.Add(coffee);
            await _context.SaveChangesAsync();

            return RedirectToAction("Products");
        }


        public IActionResult Contact()
        {
            return View(); 
        }
    }
}
