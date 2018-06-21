using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartCommuteEmmet.Data;
using SmartCommuteEmmet.Models;

namespace SmartCommuteEmmet.Controllers
{
    public class BreakfastsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BreakfastsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Breakfasts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Breakfast.ToListAsync());
        }

        // GET: Breakfasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfast = await _context.Breakfast
                .SingleOrDefaultAsync(m => m.Id == id);
            if (breakfast == null)
            {
                return NotFound();
            }

            return View(breakfast);
        }

        // GET: Breakfasts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Breakfasts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BreakfastName,BreakfastDescription,BreakfastStreet,BreakfastCity,BreakfastZIP,BreakfastLink")] Breakfast breakfast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breakfast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(breakfast);
        }

        // GET: Breakfasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfast = await _context.Breakfast.SingleOrDefaultAsync(m => m.Id == id);
            if (breakfast == null)
            {
                return NotFound();
            }
            return View(breakfast);
        }

        // POST: Breakfasts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BreakfastName,BreakfastDescription,BreakfastStreet,BreakfastCity,BreakfastZIP,BreakfastLink")] Breakfast breakfast)
        {
            if (id != breakfast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breakfast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreakfastExists(breakfast.Id))
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
            return View(breakfast);
        }

        // GET: Breakfasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfast = await _context.Breakfast
                .SingleOrDefaultAsync(m => m.Id == id);
            if (breakfast == null)
            {
                return NotFound();
            }

            return View(breakfast);
        }

        // POST: Breakfasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var breakfast = await _context.Breakfast.SingleOrDefaultAsync(m => m.Id == id);
            _context.Breakfast.Remove(breakfast);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreakfastExists(int id)
        {
            return _context.Breakfast.Any(e => e.Id == id);
        }
    }
}
