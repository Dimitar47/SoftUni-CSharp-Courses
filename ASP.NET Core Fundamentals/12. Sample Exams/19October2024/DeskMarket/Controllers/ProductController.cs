using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using System.Security.Policy;
using static DeskMarket.Constants.ModelConstants;

namespace DeskMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            var model = new ProductViewModel();

            model.Categories = await GetCategories();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                model.Categories = await GetCategories();
                return View(model);
            }

            DateTime addedOn;


            if (DateTime.TryParseExact(model.AddedOn,ProductAddedOnFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out addedOn)
                == false)
            {
                ModelState.AddModelError(nameof(model.AddedOn), "Invalid date format");
                model.Categories = await GetCategories();

                return View(model);
            }

            Product product = new Product()
            {
                ProductName = model.ProductName,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                SellerId = GetCurrentUserId() ?? string.Empty,
                AddedOn = addedOn,
                CategoryId = model.CategoryId,




            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var currentUserId = GetCurrentUserId() ?? string.Empty;
            var model = await context.Products
                .Where(p => p.IsDeleted == false)
                .Include(p=> p.ProductsClients)
                .Select(p => new ProductInfoViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    IsSeller = p.SellerId == currentUserId,  
                    HasBought = p.ProductsClients.Any(pc => pc.ClientId == currentUserId)
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cart()
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await context.Products
                .Where(p => p.IsDeleted == false)
              .Where(p => p.ProductsClients.Any(x => x.ClientId == currentUserId)) 
                .Select(p => new CartViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(int id)
        {
            Product? existingProduct= await context.Products.Where(x => x.Id == id).Include(x => x.ProductsClients).FirstOrDefaultAsync();

            if (existingProduct == null || existingProduct.IsDeleted)
            {
                throw new ArgumentException("Invalid id");
            }
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            if (existingProduct.ProductsClients.Any(x => x.ClientId == currentUserId)) 
            {

                return RedirectToAction(nameof(Index));

            }

            existingProduct.ProductsClients.Add(new ProductClient { ClientId = currentUserId, Product = existingProduct });

            await context.SaveChangesAsync();



            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            Product? existingProduct = await context.Products.Where(x => x.Id == id).Include(x => x.ProductsClients).FirstOrDefaultAsync();

            if (existingProduct == null || existingProduct.IsDeleted)
            {
                throw new ArgumentException("Invalid id");
            }
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            ProductClient? productClient = existingProduct.ProductsClients.FirstOrDefault(x => x.ClientId == currentUserId);
            if (productClient != null)
            {
                existingProduct.ProductsClients.Remove(productClient);

                await context.SaveChangesAsync();
            }



            return RedirectToAction(nameof(Cart));
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {

         var currentUserId = GetCurrentUserId() ?? string.Empty;

         var model = await context.Products
        .Include(p => p.Seller)
        .Include(p => p.Category)
        .Include(p => p.ProductsClients)
        .Where(p => p.Id == id && !p.IsDeleted)
        .Select(p => new ProductDetailsViewModel()
            {
            Id = p.Id,
            ProductName = p.ProductName,
            Description = p.Description,
            Price = p.Price,
            ImageUrl = p.ImageUrl,
            Seller = p.Seller.UserName ?? string.Empty,  
            SellerId = p.SellerId,
            AddedOn = p.AddedOn.ToString(ProductAddedOnFormat), 
            CategoryName = p.Category.Name,
            HasBought = p.ProductsClients.Any(pc => pc.ClientId == currentUserId)
        }).FirstOrDefaultAsync();



            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await context.Products.Where(p => p.Id == id)
                .Where(p => p.IsDeleted == false).AsNoTracking().Select(p => new EditViewModel
                {
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    AddedOn = p.AddedOn.ToString(ProductAddedOnFormat),
                    CategoryId = p.CategoryId,
                    SellerId = GetCurrentUserId() ?? string.Empty
                }).FirstOrDefaultAsync();

            model.Categories = await GetCategories();
            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> Edit(EditViewModel model, int id)
        {
            if (ModelState.IsValid == false)
            {
                model.Categories = await GetCategories();
                return View(model);
            }

            DateTime addedOn;


            if (DateTime.TryParseExact(model.AddedOn, ProductAddedOnFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out addedOn)
                == false)
            {
                ModelState.AddModelError(nameof(model.AddedOn), "Invalid date format");
                model.Categories = await GetCategories();

                return View(model);
            }
            Product? existingProduct = await context.Products.FindAsync(id);

            if (existingProduct == null || existingProduct.IsDeleted)
            {
                throw new ArgumentException("Invalid id");
            }
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            if (existingProduct.SellerId != currentUserId)
            {
                return RedirectToAction(nameof(Index));
            }

            existingProduct.ProductName = model.ProductName;
            existingProduct.Price = model.Price;
            existingProduct.Description = model.Description;
            existingProduct.ImageUrl = model.ImageUrl;
            existingProduct.AddedOn = addedOn;
            existingProduct.CategoryId = model.CategoryId;
            existingProduct.SellerId = GetCurrentUserId() ?? string.Empty;






            await context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = existingProduct.Id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var currentUserId = GetCurrentUserId();

    
            var product = await context.Products
                .Where(p => p.Id == id && p.SellerId == currentUserId && !p.IsDeleted)
                .Select(p => new DeleteViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Seller = p.Seller.UserName ?? string.Empty,
                    SellerId = p.SellerId
                })
                .FirstOrDefaultAsync();

            return View(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(DeleteViewModel model)
        {
            var currentUserId = GetCurrentUserId();

            
            var product = await context.Products
                .Where(p => p.Id == model.Id && p.SellerId == currentUserId && !p.IsDeleted)
                .FirstOrDefaultAsync();

            if (product != null)
            {
                product.IsDeleted = true;

                await context.SaveChangesAsync();
            }

          

            
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]


        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<List<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

    }
}
