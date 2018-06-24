using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartCommuteEmmet.Data;
using SmartCommuteEmmet.Models;

namespace SmartCommuteEmmet.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StartPointsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StartPointsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StartPoints
        public async Task<IActionResult> Index()
        {
            return View(await _context.StartPoint.Where(c=>c.UserId == null).ToListAsync());
        }

        // GET: StartPoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var startPoint = await _context.StartPoint
                .SingleOrDefaultAsync(m => m.Id == id);
            if (startPoint == null)
            {
                return NotFound();
            }

            return View(startPoint);
        }

        // GET: StartPoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StartPoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartPointName,StartPointDescription,StartPointLongitude,StartPointLatitude,UserId")] StartPoint startPoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(startPoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(startPoint);
        }

        // GET: StartPoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var startPoint = await _context.StartPoint.SingleOrDefaultAsync(m => m.Id == id);
            if (startPoint == null)
            {
                return NotFound();
            }
            return View(startPoint);
        }

        // POST: StartPoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartPointName,StartPointDescription,StartPointLongitude,StartPointLatitude,UserId")] StartPoint startPoint)
        {
            if (id != startPoint.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(startPoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StartPointExists(startPoint.Id))
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
            return View(startPoint);
        }

        // GET: StartPoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var startPoint = await _context.StartPoint
                .SingleOrDefaultAsync(m => m.Id == id);
            if (startPoint == null)
            {
                return NotFound();
            }

            return View(startPoint);
        }

        // POST: StartPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var startPoint = await _context.StartPoint.SingleOrDefaultAsync(m => m.Id == id);
            _context.StartPoint.Remove(startPoint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StartPointExists(int id)
        {
            return _context.StartPoint.Any(e => e.Id == id);
        }
    }
}
