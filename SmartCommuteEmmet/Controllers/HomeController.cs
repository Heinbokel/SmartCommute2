using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartCommuteEmmet.Data;
using SmartCommuteEmmet.Models;
using SmartCommuteEmmet.Models.HomeViewModels;

namespace SmartCommuteEmmet.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel()
            {
                TotalCommutes = _context.Commute.Count(),
                TotalDistance = _context.Commute.Sum(c=>c.CommuteDistance),
                GasSaved = (_context.Commute.Sum(c=>c.CommuteDistance)/23),
                CarbonReduced = ((_context.Commute.Sum(c => c.CommuteDistance) / 23)*20),
                ConfigDate = _context.ConfigDate.SingleOrDefault()
            };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
