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
    [Authorize(Roles = "Admin")]
    public class CommuteTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommuteTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CommuteTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CommuteType.ToListAsync());
        }

        // GET: CommuteTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commuteType = await _context.CommuteType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (commuteType == null)
            {
                return NotFound();
            }

            return View(commuteType);
        }

        // GET: CommuteTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CommuteTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CommuteTypeName,CommutePointsAwarded,CommuteTypeDescription")] CommuteType commuteType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commuteType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commuteType);
        }

        // GET: CommuteTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commuteType = await _context.CommuteType.SingleOrDefaultAsync(m => m.Id == id);
            if (commuteType == null)
            {
                return NotFound();
            }
            return View(commuteType);
        }

        // POST: CommuteTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CommuteTypeName,CommutePointsAwarded,CommuteTypeDescription")] CommuteType commuteType)
        {
            if (id != commuteType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commuteType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommuteTypeExists(commuteType.Id))
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
            return View(commuteType);
        }

        // GET: CommuteTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commuteType = await _context.CommuteType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (commuteType == null)
            {
                return NotFound();
            }

            return View(commuteType);
        }

        // POST: CommuteTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commuteType = await _context.CommuteType.SingleOrDefaultAsync(m => m.Id == id);
            _context.CommuteType.Remove(commuteType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommuteTypeExists(int id)
        {
            return _context.CommuteType.Any(e => e.Id == id);
        }
    }
}
