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
    public class ConfigDatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfigDatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConfigDates
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConfigDate.ToListAsync());
        }

        // GET: ConfigDates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configDate = await _context.ConfigDate
                .SingleOrDefaultAsync(m => m.Id == id);
            if (configDate == null)
            {
                return NotFound();
            }

            return View(configDate);
        }

        // GET: ConfigDates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConfigDates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,RegisterByDate")] ConfigDate configDate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configDate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(configDate);
        }

        // GET: ConfigDates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configDate = await _context.ConfigDate.SingleOrDefaultAsync(m => m.Id == id);
            if (configDate == null)
            {
                return NotFound();
            }
            return View(configDate);
        }

        // POST: ConfigDates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,RegisterByDate")] ConfigDate configDate)
        {
            if (id != configDate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configDate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigDateExists(configDate.Id))
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
            return View(configDate);
        }

        // GET: ConfigDates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configDate = await _context.ConfigDate
                .SingleOrDefaultAsync(m => m.Id == id);
            if (configDate == null)
            {
                return NotFound();
            }

            return View(configDate);
        }

        // POST: ConfigDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configDate = await _context.ConfigDate.SingleOrDefaultAsync(m => m.Id == id);
            _context.ConfigDate.Remove(configDate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfigDateExists(int id)
        {
            return _context.ConfigDate.Any(e => e.Id == id);
        }
    }
}
