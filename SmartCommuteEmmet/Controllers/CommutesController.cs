using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartCommuteEmmet.Data;
using SmartCommuteEmmet.Models;
using SmartCommuteEmmet.Models.LeaderboardViewModels;
using SmartCommuteEmmet.Models.ProfileViewModels;

namespace SmartCommuteEmmet.Controllers
{
    public class CommutesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public CommutesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Commutes
        public async Task<IActionResult> Index()
        {
            ApplicationUser CurrentUser = await _userManager.GetUserAsync(HttpContext.User);
            var applicationDbContext = _context.Commute.Include(c => c.CommuteType).Include(c => c.EndPoint).Include(c => c.StartPoint).Include(c => c.User).Where(c => c.UserId == CurrentUser.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Commutes/Details/5
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
        public IActionResult Create()
        {
            ViewData["CommuteTypeId"] = new SelectList(_context.CommuteType, "Id", "CommuteTypeName");
            ViewData["EndPointId"] = new SelectList(_context.Set<EndPoint>(), "Id", "EndPointName");
            ViewData["StartPointId"] = new SelectList(_context.Set<StartPoint>(), "Id", "StartPointName");
            return View();
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
            //if (ModelState.IsValid) TODO:WHY IS MODEL STATE INVALID???
            {
                _context.Add(commute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommuteTypeId"] = new SelectList(_context.CommuteType, "Id", "CommuteTypeName", commute.CommuteTypeId);
            ViewData["EndPointId"] = new SelectList(_context.Set<EndPoint>(), "Id", "EndPointName", commute.EndPointId);
            ViewData["StartPointId"] = new SelectList(_context.Set<StartPoint>(), "Id", "StartPointName", commute.StartPointId);
            return View(commute);
        }

        // GET: Commutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commute = await _context.Commute.SingleOrDefaultAsync(m => m.Id == id);
            if (commute == null)
            {
                return NotFound();
            }
            ViewData["CommuteTypeId"] = new SelectList(_context.CommuteType, "Id", "CommuteTypeDescription", commute.CommuteTypeId);
            ViewData["EndPointId"] = new SelectList(_context.Set<EndPoint>(), "Id", "EndPointDescription", commute.EndPointId);
            ViewData["StartPointId"] = new SelectList(_context.Set<StartPoint>(), "Id", "StartPointDescription", commute.StartPointId);
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
            ViewData["CommuteTypeId"] = new SelectList(_context.CommuteType, "Id", "CommuteTypeDescription", commute.CommuteTypeId);
            ViewData["EndPointId"] = new SelectList(_context.Set<EndPoint>(), "Id", "EndPointDescription", commute.EndPointId);
            ViewData["StartPointId"] = new SelectList(_context.Set<StartPoint>(), "Id", "StartPointDescription", commute.StartPointId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", commute.UserId);
            return View(commute);
        }

        public IActionResult Leaderboards()
        {
            var model = new LeaderboardViewModel
            {
                Commutes = _context.Commute.ToList(),
                Users = _context.Users.ToList()
            };
            return View();
        }

        // GET: Commutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
    }
}
