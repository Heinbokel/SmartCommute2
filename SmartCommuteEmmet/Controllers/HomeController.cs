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
            var sponsorModel = new AboutViewModel();
            sponsorModel.Breakfasts = new List<Breakfast>();
            sponsorModel.Sponsors = new List<Sponsor>();

            var Sponsors = _context.Sponsor.ToList();
            var Breakfasts = _context.Breakfast.ToList();

            foreach (var sponsor in Sponsors)
            {
                var userViewModel = new Sponsor
                {
                    Id = sponsor.Id,
                    SponsorLink = sponsor.SponsorLink,
                    SponsorImagePath = sponsor.SponsorImagePath,
                    SponsorDescription = sponsor.SponsorDescription,
                    SponsorName = sponsor.SponsorName
                };
                sponsorModel.Sponsors.Add(userViewModel);
            }

            foreach (var breakfast in Breakfasts)
            {
                var userViewModel = new Breakfast
                {
                    Id = breakfast.Id,
                    BreakfastName = breakfast.BreakfastName,
                    BreakfastDescription = breakfast.BreakfastDescription,
                    BreakfastCity = breakfast.BreakfastCity,
                    BreakfastLink = breakfast.BreakfastLink,
                    BreakfastStreet = breakfast.BreakfastStreet,
                    BreakfastZIP = breakfast.BreakfastZIP
                    
                };
                sponsorModel.Breakfasts.Add(userViewModel);
            }

            return View(sponsorModel);
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
