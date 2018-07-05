using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartCommuteEmmet.Data;
using SmartCommuteEmmet.Models;

namespace SmartCommuteEmmet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarouselSponsorImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _environment;

        public CarouselSponsorImagesController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: CarouselSponsorImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarouselSponsorImage.ToListAsync());
        }

        // GET: CarouselSponsorImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carouselSponsorImage = await _context.CarouselSponsorImage
                .SingleOrDefaultAsync(m => m.Id == id);
            if (carouselSponsorImage == null)
            {
                return NotFound();
            }

            return View(carouselSponsorImage);
        }

        // GET: CarouselSponsorImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarouselSponsorImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarouselImagePath,DateUploaded")] CarouselSponsorImage carouselSponsorImage)
        {
            if (ModelState.IsValid)
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
                        fileName = Path.Combine(_environment.WebRootPath, "carouselSponsorPhoto") + $@"\{newFileName}";

                        // if you want to store path of folder in database
                        carouselSponsorImage.CarouselImagePath = "carouselSponsorPhoto/" + newFileName;

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                    else
                    {
                        carouselSponsorImage.CarouselImagePath = null;
                    }
                }


                _context.Add(carouselSponsorImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carouselSponsorImage);
        }

        // GET: CarouselSponsorImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carouselSponsorImage = await _context.CarouselSponsorImage.SingleOrDefaultAsync(m => m.Id == id);
            carouselSponsorImage.DateUploaded = DateTime.Now;
            if (carouselSponsorImage == null)
            {
                return NotFound();
            }
            return View(carouselSponsorImage);
        }

        // POST: CarouselSponsorImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarouselImagePath,DateUploaded")] CarouselSponsorImage carouselSponsorImage)
        {
            if (id != carouselSponsorImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
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
                            fileName = Path.Combine(_environment.WebRootPath, "carouselSponsorPhoto") + $@"\{newFileName}";

                            // if you want to store path of folder in database
                            carouselSponsorImage.CarouselImagePath = "carouselSponsorPhoto/" + newFileName;

                            using (FileStream fs = System.IO.File.Create(fileName))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }
                        }
                        else
                        {
                            if(carouselSponsorImage.CarouselImagePath == null)
                            {
                                carouselSponsorImage.CarouselImagePath = null;
                            }
                            else
                            {
                                carouselSponsorImage.CarouselImagePath = _context.CarouselSponsorImage.Select(c => c.CarouselImagePath).FirstOrDefault();
                            }
                        }
                    }

                    _context.Update(carouselSponsorImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarouselSponsorImageExists(carouselSponsorImage.Id))
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
            return View(carouselSponsorImage);
        }

        private bool CarouselSponsorImageExists(int id)
        {
            return _context.CarouselSponsorImage.Any(e => e.Id == id);
        }
    }
}
