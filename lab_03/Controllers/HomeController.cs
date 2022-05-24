using lab_03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace lab_03.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Car[] cars =
            {
                new Car {Id = 1, Name = "A3", BasePrice = 1000, Description = "A car description", Manufacturer = "Audi", MaxSpeedInMPH = 1000000},
                new Car {Id = 2, Name = "Model S", BasePrice= 500, Description = "An electric car", Manufacturer = "Tesla", MaxSpeedInMPH = 12},
                new Car {Id = 3, Name = "WRV", BasePrice = 12, Description = "WRV", Manufacturer = "Hunda", MaxSpeedInMPH = 999 },
                new Car {Id = 4, Name = "Grand i10", BasePrice = 15, Description = "Lazy description #2", Manufacturer = "Hyundai", MaxSpeedInMPH = 9000}
            };
            return View(cars.Where(el => el.BasePrice > 10000));
        }
    }
}
