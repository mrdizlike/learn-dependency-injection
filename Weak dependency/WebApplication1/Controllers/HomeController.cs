using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly IProductService productService;

    public HomeController(IProductService productService)
    {
        if (productService == null)
            throw new ArgumentNullException("productService");

        this.productService = productService;
    }

    public IActionResult Index()
    {
        IEnumerable<DiscountedProduct> products = this.productService.GetFeaturedProducts();

        var vm = new FeaturedProductsViewModel(
            from product in products
            select new ProductViewModel(product.Name, product.UnitPrice));

        return this.View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
