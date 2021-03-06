﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartCommuteEmmet.Data;
using SmartCommuteEmmet.Models;
using SmartCommuteEmmet.Models.ProfileViewModels;

namespace SmartCommuteEmmet.Controllers
{
    public class ProfilesController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfilesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: Profiles
        public ActionResult Index()
        {
            return View();
        }

        // GET: Profiles/Profile/5
        public async Task<ActionResult> Profile(string id)
        {
            //var user = await _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            //}

            var user = await _context.Users.FindAsync(id);
            var business = _context.Business.Where(c => c.Id == user.BusinessId);

            var model = new ProfileViewModel
            {
                FirstName = user.FirstName, LastName = user.LastName, BusinessName = business.Select(c => c.BusinessName).Single(), DateRegistered = user.DateRegistered, UserBio = user.UserBio, UserPhoto = user.UserPhoto,
                Commutes = _context.Commute.Where(c => c.UserId == user.Id).ToList(),
                UserId = user.Id,
                BusinessId = business.Select(c=>c.Id).Single(),
                Documents = _context.Document.ToList(),
                Rewards = _context.Reward.Where(c => c.RequiredMiles <= _context.Commute.Where(w => w.UserId == user.Id).Sum(s => s.CommuteDistance)).ToList()
        };
            if(model.Rewards.Count == 0)
            {
                model.Rewards = new List<Reward>
                {
                    new Reward
                    {
                        RewardName = "No Rewards",
                        RewardDescription ="You have not earned any rewards yet. Keep commuting smart to earn some!",
                        IsGrandPrize = false, RequiredCommutes = 1, RequiredMiles = 1
                    }
                };
            }

            return View(model);
        }

        // GET: Profiles/Profile/5
        public IActionResult BusinessProfile(int id)
        {
            var business = _context.Business.Find(id);
            var users = _context.Users.Where(c => c.BusinessId == id).ToList();
            var commutes = _context.Commute.Where(c => c.User.BusinessId == id).ToList();

            var model = new BusinessProfileViewModel
            {
                BusinessName = business.BusinessName,
                BusinessCity = business.BusinessCity,
                BusinessDescription = business.BusinessDescription,
                BusinessStreet = business.BusinessStreet,
                BusinessZIP = business.BusinessZIP,
                BusinessLink = business.BusinessLink,
                Commutes = commutes,
                Users = users
            };
            

            return View(model);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profiles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profiles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}