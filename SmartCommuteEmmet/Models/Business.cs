using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class Business
    {
        public int Id { get; set; }

        [Required][Display(Name ="Business Name")]
        public string BusinessName { get; set; }

        [Display(Name ="Business Description")]
        public string BusinessDescription { get; set; }

        [Display(Name = "Business Street Address")]
        public string BusinessStreet { get; set; }

        [Display(Name = "Business City")]
        public string BusinessCity { get; set; }

        [Display(Name = "Business ZIP")]
        public string BusinessZIP { get; set; }

    }
}
