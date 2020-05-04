using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SQLInjection.Database;
using SQLInjection.Models;

namespace SQLInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BestMovieContext _context;

        public HomeController(ILogger<HomeController> logger, BestMovieContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.BestMovies.ToList());
        }

        public IActionResult Search(string actor)
        {
            List<BestMovie> movies = new List<BestMovie>();

            if(!string.IsNullOrEmpty(actor))
            {
                string query = string.Format("select * from BestMovies where (actor like '%{0}%')", actor);
                movies = _context.BestMovies.FromSqlRaw(query).ToList();
                ViewBag.Actor = actor.Trim();
            }

            return View("Index", movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
