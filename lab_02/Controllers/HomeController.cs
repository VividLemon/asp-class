using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Lab_03.Models;
using System.Threading.Tasks;
using System.Linq;
namespace Lab_03.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View(new string[] { "C#", "Language", "Features" });
            //List<string> vs = new List<string>();
            //Dictionary<string, Product> products = new Dictionary<string, Product>()
            //{
            //    {"Kayak", new Product() { Name = "Kayak", Price = 275M } },
            //    {"Lifejacket", new Product() { Name = "Lifejacket", Price = 48.95M } }
            //};
            //foreach (Product product in Product.GetProducts())
            //{
            //    vs.Add($"Name: {product?.Name ?? "<No name>"} Price: {product?.Price ?? 0} Category: {product?.Category} Related: {product?.Related?.Name ?? "<None>"}");
            //}
            //return View(vs);
            //object [] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            //decimal total = 0;
            //for(int i = 0; i < data.Length; i++)
            //{
            //if(data[i] is decimal d)
            //{
            //    total += d;
            //}
            //switch (data[i])
            //{
            //    case decimal decimalValue:
            //        total += decimalValue;
            //        break;
            //    case int intValue when intValue > 50:
            //        total += intValue;
            //        break;
            //}
            //}
            //ShoppingCart cart = new ShoppingCart() { Products = Product.GetProducts() };
            //Product[] productArray = { 
            //    new Product() { Name = "Kayak", Price = 275M },
            //    new Product() { Name = "Lifejacket", Price = 48.95M },
            //    new Product {Name = "Soccer ball", Price = 19.5M },
            //    new Product { Name = "Corner flag", Price = 14.95M }  
            //};
            //bool filterByPrice (Product product)
            //{
            //    return (product?.Price ?? 0) >= 20;
            //}
            //decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();
            //decimal cartTotal = cart.TotalPrices();
            //decimal priceFilterTotal = productArray.FilterByPrice(20).TotalPrices();
            //decimal priceFilterTotalt = productArray.filter(p => (p?.Price ?? 0) >= 20).TotalPrices();
            //return View("Index", new string[] {$"Cart total: {cartTotal:C2}", $"Array total: {arrayTotal:C2}"});
            //long? length = await MyAsyncMethods.GetPageLength();
            //return View(new string[] { $"Length: {length}" });
            var products = new []
            {
                new {Name = "Kayak", Price = 275M },
                new {Name = "Lifejacket", Price = 48.95M},
                new {Name = "Soccer Ball", Price = 19.50M},
                new {Name = "Corner flag", Price = 34.95M}
            };
            return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));
        }
    }
}
