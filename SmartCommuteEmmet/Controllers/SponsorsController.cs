using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartCommuteEmmet.Data;
using SmartCommuteEmmet.Models;

namespace SmartCommuteEmmet.Controllers
{
    public class SponsorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _environment;

        public SponsorsController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Sponsors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sponsor.ToListAsync());
        }

        // GET: Sponsors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsor
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sponsor == null)
            {
                return NotFound();
            }

            return View(sponsor);
        }

        // GET: Sponsors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sponsors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SponsorName,SponsorDescription,SponsorLink,SponsorImagePath")] Sponsor sponsor)
        {//TODO: When an error occurs, the image upload is reset. Ensure image in upload slot remains the same.
            if (ModelState.IsValid)
            {
                {
                    var files = HttpContext.Request.Form.Files;

                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            //Getting FileName
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                            //Assigning Unique Filename (Guid)
                            var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                            //Getting file Extension
                            var FileExtension = Path.GetExtension(fileName);

                            // concating  FileName + FileExtension
                            var newFileName = myUniqueFileName + FileExtension;

                            // Combines two strings into a path.
                            fileName = Path.Combine(_environment.WebRootPath, "sponsorPhotos") + $@"\{newFileName}";

                            // if you want to store path of folder in database
                            sponsor.SponsorImagePath = "sponsorPhotos/" + newFileName;

                            using (FileStream fs = System.IO.File.Create(fileName))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }
                        }
                        else
                        {
                            sponsor.SponsorImagePath = null;
                        }
                    }
                }

                _context.Add(sponsor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SponsorUploadError"] = "Please re-select your image if needed.";
            return View(sponsor);
        }

        // GET: Sponsors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsor.SingleOrDefaultAsync(m => m.Id == id);
            if (sponsor == null)
            {
                return NotFound();
            }
            return View(sponsor);
        }

        // POST: Sponsors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SponsorName,SponsorDescription,SponsorLink,SponsorImagePath")] Sponsor sponsor)
        {
            if (id != sponsor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    {
                        var files = HttpContext.Request.Form.Files;

                        foreach (var file in files)
                        {
                            if (file.Length > 0)
                            {
                                //Getting FileName
                                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                                //Assigning Unique Filename (Guid)
                                var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                                //Getting file Extension
                                var FileExtension = Path.GetExtension(fileName);

                                // concating  FileName + FileExtension
                                var newFileName = myUniqueFileName + FileExtension;

                                // Combines two strings into a path.
                                fileName = Path.Combine(_environment.WebRootPath, "sponsorPhotos") + $@"\{newFileName}";

                                // if you want to store path of folder in database
                                sponsor.SponsorImagePath = "sponsorPhotos/" + newFileName;

                                using (FileStream fs = System.IO.File.Create(fileName))
                                {
                                    file.CopyTo(fs);
                                    fs.Flush();
                                }
                            }
                            else
                            {
                                sponsor.SponsorImagePath = null;
                            }
                        }
                    }
                    _context.Update(sponsor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SponsorExists(sponsor.Id))
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
            ViewData["SponsorUploadError"] = "Please re-select your image if needed.";
            return View(sponsor);
        }

        // GET: Sponsors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsor
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sponsor == null)
            {
                return NotFound();
            }

            return View(sponsor);
        }

        // POST: Sponsors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sponsor = await _context.Sponsor.SingleOrDefaultAsync(m => m.Id == id);
            _context.Sponsor.Remove(sponsor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SponsorExists(int id)
        {
            return _context.Sponsor.Any(e => e.Id == id);
        }
    }
}
