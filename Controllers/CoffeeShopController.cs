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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id","Name","Price","Type")] Coffee coffee, IFormFile? imageFile)
        {
            // Ensure server-populated required properties have values before validating model state
            coffee.Available = true; // default availability when creating

            // Handle image upload first so ImagePath is set
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
            else
            {
                // Provide a default image path (make sure this file exists in your project) or an empty string
                coffee.ImagePath = "/images/CoffeeShop/uploads/default.webp";
            }

            // Remove model state entries for properties we populated server-side so validation succeeds
            // ModelState.Remove(nameof(coffee.ImagePath));
            ModelState.Remove(nameof(coffee.Available));

            if (!ModelState.IsValid)
                return View(coffee);

            _context.CoffeeProducts.Add(coffee);
            await _context.SaveChangesAsync();

            return RedirectToAction("Products");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var findItem = await _context.CoffeeProducts.FirstOrDefaultAsync(item => item.Id == id);
            if (findItem == null)
            {
                return RedirectToAction("Products");
            }

            return View(findItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var findItem = await _context.CoffeeProducts.FirstOrDefaultAsync(item => item.Id == id);
            if (findItem == null)
            {
                TempData["itemNotFound"] = $"محصول با id = {id} یافت نشد.";
                return RedirectToAction("Products");
            }

            // Delete the image file if it exists
            if (!string.IsNullOrEmpty(findItem.ImagePath) && findItem.ImagePath != "/images/CoffeeShop/default.webp")
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", findItem.ImagePath.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            // delete item from database
            _context.CoffeeProducts.Remove(findItem);
            await _context.SaveChangesAsync();

            TempData["itemDeletesuccess"] = $"محصول با id = {id} با موفقیت پاک شد.";
            return RedirectToAction("Products");
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
