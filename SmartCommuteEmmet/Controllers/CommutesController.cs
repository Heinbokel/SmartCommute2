using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartCommuteEmmet.Data;
using SmartCommuteEmmet.Models;
using SmartCommuteEmmet.Models.CommuteViewModels;
using SmartCommuteEmmet.Models.LeaderboardViewModels;
using SmartCommuteEmmet.Models.ProfileViewModels;
using SmartCommuteEmmet.Services;

namespace SmartCommuteEmmet.Controllers
{
    public class CommutesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;


        public CommutesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        // GET: Commutes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            ApplicationUser CurrentUser = await _userManager.GetUserAsync(HttpContext.User);
            var applicationDbContext = _context.Commute.Include(c => c.CommuteType).Include(c => c.EndPoint).Include(c => c.StartPoint).Include(c => c.User).Where(c => c.UserId == CurrentUser.Id).OrderBy(c=>c.CommuteDate);
            return View(await applicationDbContext.ToListAsync());
        }

        //Check Two commutes per day rule
        public bool CheckCommuteCountForDate(Commute commute, ApplicationUser currentUser)
        {
            var commuteCountForDate = _context.Commute.Where(c => c.UserId == currentUser.Id && c.CommuteDate.ToShortDateString() == commute.CommuteDate.ToShortDateString()).Count();
            if(commuteCountForDate >= 2)
            {
                ViewBag.DateError = "There are already 2 commutes entered for this date. Please change the date.";
                return false;//False = Too many commutes for this date.
            }
            ViewBag.DateError = "";
            return true;//True = May add this commute for this date.
        }

        //Get Saved Commutes
        [Authorize]
        public List<SavedCommuteViewModel> GetSavedCommutes(ApplicationUser currentUser)
        {
            ApplicationUser CurrentUser = currentUser;
            var savedCommutes = _context.Commute.Where(c => c.UserId == CurrentUser.Id && c.CommuteSaved == true).ToList();

            var model = new List<SavedCommuteViewModel>();

            foreach (var item in savedCommutes)
            {
                var commute = new SavedCommuteViewModel
                {
                    CommuteName = item.CommuteName,
                    CommuteDescription = item.CommuteDescription,
                    CommuteDistance = item.CommuteDistance,
                    UserId = item.UserId,
                    CommuteId = item.Id
                };
                model.Add(commute);
            }
            return model.ToList();
        }


        public async Task<IActionResult> CreateFromSaved(int id)
        {
            ApplicationUser CurrentUser = await _userManager.GetUserAsync(HttpContext.User);
            var savedCommute = _context.Commute.Find(id);
            var commute = new Commute()
            {
                CommuteDate = DateTime.Now,
                CommuteTypeId = savedCommute.CommuteTypeId,
                CommuteDescription = savedCommute.CommuteDescription,
                CommuteDistance = savedCommute.CommuteDistance,
                CommuteName = savedCommute.CommuteName,
                CommuteSaved = false,
                EndPointId = savedCommute.EndPointId,
                StartPointId = savedCommute.StartPointId,
                UserId = savedCommute.UserId
            };

            //If this date contains 2 or more commutes for this user, do not let them post.
            if (CheckCommuteCountForDate(commute, CurrentUser))
            {
                if (ModelState.IsValid)
                {
                    _context.Add(commute);
                    await _context.SaveChangesAsync();
                    if(CurrentUser.IsSubscribed == true)
                    {
                        SendCommuteSummaryEmail(commute, CurrentUser);
                    }
                    return RedirectToAction(nameof(Index));
                }
            }

            
            ViewData["StartDate"] = _context.ConfigDate.Select(c => c.StartDate).SingleOrDefault();
            ViewData["EndDate"] = _context.ConfigDate.Select(c => c.EndDate).SingleOrDefault();
            ViewData["SavedCommutes"] = GetSavedCommutes(CurrentUser);
            ViewData["CommuteTypeId"] = new SelectList(_context.CommuteType, "Id", "CommuteTypeName", commute.CommuteTypeId);
            ViewData["EndPointId"] = new SelectList(_context.Set<EndPoint>(), "Id", "EndPointName", commute.EndPointId);
            ViewData["StartPointId"] = new SelectList(_context.Set<StartPoint>(), "Id", "StartPointName", commute.StartPointId);
            return View("Create", commute);
        }

        // GET: Commutes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commute = await _context.Commute
                .Include(c => c.CommuteType)
                .Include(c => c.EndPoint)
                .Include(c => c.StartPoint)
                .Include(c => c.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (commute == null)
            {
                return NotFound();
            }

            return View(commute);
        }

        // GET: Commutes/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            ApplicationUser CurrentUser = await _userManager.GetUserAsync(HttpContext.User);

            ViewBag.DateError = "";
            ViewData["StartDate"] = _context.ConfigDate.Select(c => c.StartDate).SingleOrDefault();
            ViewData["EndDate"] = _context.ConfigDate.Select(c => c.EndDate).SingleOrDefault();
            ViewData["SavedCommutes"] = GetSavedCommutes(CurrentUser);
            ViewData["CommuteTypeId"] = new SelectList(_context.CommuteType, "Id", "CommuteTypeName");
            ViewData["EndPointId"] = new SelectList(_context.Set<EndPoint>().Where(c=>c.UserId == null || c.UserId == CurrentUser.Id).OrderBy(c=> c.EndPointName), "Id", "EndPointName");
            ViewData["StartPointId"] = new SelectList(_context.Set<StartPoint>().Where(c => c.UserId == null || c.UserId == CurrentUser.Id).OrderBy(c => c.StartPointName), "Id", "StartPointName");
            var model = new Commute()
            {
                CommuteDate = DateTime.Now 
            };
            return View(model);
        }

        // POST: Commutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CommuteDistance,CommuteDescription,CommuteSaved,CommuteName,CommuteDate,CommuteTypeId,StartPointId,StartPointCustom,EndPointId,EndPointCustom,UserId,User")] Commute commute)
        {
            ApplicationUser CurrentUser = await _userManager.GetUserAsync(HttpContext.User);
            commute.UserId = CurrentUser.Id;

            if (commute.StartPointId == 0)
            {
                commute.StartPointId = null;

                commute.StartPoint = new StartPoint()
                {
                    StartPointName = commute.StartPointCustom,
                    UserId = CurrentUser.Id
                };
            }

            if (commute.EndPointId == 0)
            {
                commute.EndPointId = null;

                commute.EndPoint = new EndPoint()
                {
                    EndPointName = commute.EndPointCustom,
                    UserId = CurrentUser.Id
                };
            }

            //If date has 2 or more commutes entered, prevent this entry.
            if(CheckCommuteCountForDate(commute, CurrentUser))
            {
                if (ModelState.IsValid)
                {
                    _context.Add(commute);
                    await _context.SaveChangesAsync();
                    if (CurrentUser.IsSubscribed == true)
                    {
                        SendCommuteSummaryEmail(commute, CurrentUser);
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["StartDate"] = _context.ConfigDate.Select(c => c.StartDate).SingleOrDefault();
            ViewData["EndDate"] = _context.ConfigDate.Select(c => c.EndDate).SingleOrDefault();
            ViewData["SavedCommutes"] = GetSavedCommutes(CurrentUser);
            ViewData["CommuteTypeId"] = new SelectList(_context.CommuteType, "Id", "CommuteTypeName", commute.CommuteTypeId);
            ViewData["EndPointId"] = new SelectList(_context.Set<EndPoint>(), "Id", "EndPointName", commute.EndPointId);
            ViewData["StartPointId"] = new SelectList(_context.Set<StartPoint>(), "Id", "StartPointName", commute.StartPointId);
            return View(commute);
        }

        // GET: Commutes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser CurrentUser = await _userManager.GetUserAsync(HttpContext.User);

            var commute = await _context.Commute.SingleOrDefaultAsync(m => m.Id == id);
            if (commute == null || (commute.UserId != CurrentUser.Id && !User.IsInRole("Admin")))
            {
                return NotFound();
            }
            ViewData["CommuteTypeId"] = new SelectList(_context.CommuteType, "Id", "CommuteTypeName", commute.CommuteTypeId);
            ViewData["EndPointId"] = new SelectList(_context.Set<EndPoint>(), "Id", "EndPointName", commute.EndPointId);
            ViewData["StartPointId"] = new SelectList(_context.Set<StartPoint>(), "Id", "StartPointName", commute.StartPointId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", commute.UserId);
            return View(commute);
        }

        // POST: Commutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CommuteDistance,CommuteDescription,CommuteSaved,CommuteName,CommuteDate,CommuteTypeId,StartPointId,StartPointCustom,EndPointId,EndPointCustom,UserId")] Commute commute)
        {
            ApplicationUser CurrentUser = await _userManager.GetUserAsync(HttpContext.User);
            commute.UserId = CurrentUser.Id;

            if (commute.StartPointId == 0)
            {
                commute.StartPointId = null;

                commute.StartPoint = new StartPoint()
                {
                    StartPointName = commute.StartPointCustom,
                    UserId = CurrentUser.Id
                };
            }

            if (commute.EndPointId == 0)
            {
                commute.EndPointId = null;

                commute.EndPoint = new EndPoint()
                {
                    EndPointName = commute.EndPointCustom,
                    UserId = CurrentUser.Id
                };
            }

            if (id != commute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommuteExists(commute.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommuteTypeId"] = new SelectList(_context.CommuteType, "Id", "CommuteTypeName", commute.CommuteTypeId);
            ViewData["EndPointId"] = new SelectList(_context.Set<EndPoint>(), "Id", "EndPointName", commute.EndPointId);
            ViewData["StartPointId"] = new SelectList(_context.Set<StartPoint>(), "Id", "StartPointName", commute.StartPointId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", commute.UserId);
            return View(commute);
        }

        public IActionResult Leaderboards()
        {
            var model = new List<LeaderboardViewModel>();
            var Commutes = _context.Commute.Where(c=>c.CommuteDate.Year == DateTime.Now.Year).ToList();
            var Users = _context.Users.Include(c=>c.Business).Where(c=>c.Email != "Admin@smartcommuteemmet.org").ToList();

            foreach(var user in Users)
            {
                var userViewModel = new LeaderboardViewModel
                {
                    UserName = user.FirstName + " " + user.LastName,
                    UserPhoto = user.UserPhoto,
                    UserId = user.Id,
                    TotalCommutes = Commutes.Where(c => c.UserId == user.Id).Count(),
                    BikeCommutes = Commutes.Where(c=> c.UserId == user.Id && c.CommuteTypeId == 1).Count(),
                    RunCommutes = Commutes.Where(c => c.UserId == user.Id && c.CommuteTypeId == 3).Count(),
                    CarpoolCommutes = Commutes.Where(c => c.UserId == user.Id && c.CommuteTypeId == 2).Count(),
                    TotalDistance = Commutes.Where(c => c.UserId == user.Id).Sum(c=> c.CommuteDistance),
                    UserBusiness = user.Business
                };
                model.Add(userViewModel);
            }

            return View(model.ToList());
        }

        public IActionResult LeaderboardsBusiness()
        {
            var model = new List<LeaderboardsBusinessViewModel>();
            var Commutes = _context.Commute.Where(c => c.CommuteDate.Year == DateTime.Now.Year).Include(c => c.User).ToList();
            var Businesses = _context.Business.ToList();
            var Users = _context.Users.Where(c => c.Email != "admin@smartcommuteemmet.org").ToList();

            foreach (var business in Businesses)
            {
                var userViewModel = new LeaderboardsBusinessViewModel
                {
                    BusinessId = business.Id, BusinessName = business.BusinessName, TeamSize = Users.Where(c =>  c.BusinessId == business.Id).Count(),
                    TotalCommutes = Commutes.Where(c=> c.User.BusinessId == business.Id).Count(),
                    TotalDistance = Commutes.Where(c => c.User.BusinessId == business.Id).Sum(c=> c.CommuteDistance),
                    TotalBikes = Commutes.Where(c => c.User.BusinessId == business.Id && c.CommuteTypeId == 1).Count(),
                    TotalCarpools = Commutes.Where(c => c.User.BusinessId == business.Id && c.CommuteTypeId == 2).Count(),
                    TotalRuns = Commutes.Where(c => c.User.BusinessId == business.Id && c.CommuteTypeId == 3).Count(),

                };
                model.Add(userViewModel);
            }

            return View(model.ToList());
        }

        // GET: Commutes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser CurrentUser = await _userManager.GetUserAsync(HttpContext.User);

            var commute = await _context.Commute
                .Include(c => c.CommuteType)
                .Include(c => c.EndPoint)
                .Include(c => c.StartPoint)
                .Include(c => c.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (commute == null || (commute.UserId != CurrentUser.Id && !User.IsInRole("Admin")))
            {
                return NotFound();
            }

            return View(commute);
        }

        // POST: Commutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commute = await _context.Commute.SingleOrDefaultAsync(m => m.Id == id);
            _context.Commute.Remove(commute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommuteExists(int id)
        {
            return _context.Commute.Any(e => e.Id == id);
        }

        public async void SendCommuteSummaryEmail(Commute commute, ApplicationUser user)
        {
            var totalCommutes = _context.Commute.Where(c => c.UserId == commute.UserId).Count();
            var totalDistance = _context.Commute.Where(c => c.UserId == commute.UserId).Sum(c => c.CommuteDistance);
            var email = user.Email;
            var subject = "Congratulations on logging a Smart Commute!";

            var message = "<h1 style='color:white;background-color:black;text-align:center;padding:5px;margin:0px;border-radius: 10px 10px 0px 0px;'>Smart Commute Logged!</h1>";
            message += "<div style='background-color:darkcyan;color:white;text-align:center;padding:5px;margin:0px;border-radius: 0px 0px 10px 10px;'>";
            message += "<strong>Commute Name:</strong> " + commute.CommuteName + "<br/>";
            message += "<strong>Commute Distance:</strong> " + commute.CommuteDistance + "<br/>";
            message += "<strong>Commute Description:</strong> " + commute.CommuteDescription + "<br/>";
            message += "<strong>Commute Date:</strong> " + commute.CommuteDate + "<br/>";
            message += "<br/>";
            message += "<strong>Total Commutes:</strong> " + totalCommutes + "<br/>" + "<strong>Total Distance:</strong> " + totalDistance + "<br/><br/>";
            message += "Thank you for participating!<br/>Make sure to check your rewards on your Profile Page by selecting the Rewards button.";
            message += "</div>";
            await _emailSender.SendEmailAsync(email, subject, message);
        }
    }
}
