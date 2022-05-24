using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_06.Data;
using Lab_06.Models;

namespace Lab_06.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreRepository _context;

        public GenresController(IGenreRepository context)
        {
            _context = context;
        }

        // GET: Genres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Genres.ToListAsync());
        }
    }
}
