﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models.ProfileViewModels
{
    public class ProfileViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserBio { get; set; }
        public DateTime DateRegistered { get; set; }
        public string UserPhoto { get; set; }

        public string BusinessName { get; set; }
        public int BusinessId { get; set; }

        public List<Commute> Commutes { get; set; }

        public List<Document> Documents { get; set; }

        public List<Reward> Rewards { get; set; }
    }
}
