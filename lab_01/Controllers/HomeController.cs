using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_02.Models;

namespace Lab_02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.GetCds);
        }
        [HttpGet]
        public ViewResult CDForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult CDForm(CD cd)
        {
            if (ModelState.IsValid)
            {
                Repository.AddCd(cd);
                return View("Index", Repository.GetCds);
            }
            else
            {
                return View();
            }
        }
    }
}
