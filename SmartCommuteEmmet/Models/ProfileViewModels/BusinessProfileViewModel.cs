using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models.ProfileViewModels
{
    public class BusinessProfileViewModel
    {
        
        [Display(Name = "Name")]
        public string BusinessName { get; set; }

        [Display(Name = "Description")]
        public string BusinessDescription { get; set; }

        [Display(Name = "Street")]
        public string BusinessStreet { get; set; }

        [Display(Name = "City")]
        public string BusinessCity { get; set; }

        [Display(Name = "ZIP")]
        public string BusinessZIP { get; set; }

        [Display(Name ="Link")]
        public string BusinessLink { get; set; }

        public List<ApplicationUser> Users { get; set; }
        public List<Commute> Commutes { get; set; }
    }
}
