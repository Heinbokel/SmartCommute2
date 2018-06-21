using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class Breakfast
    {
        public int Id { get; set; }

        [Required][Display(Name ="Breakfast Provider Name")]
        public string BreakfastName { get; set; }

        [Display(Name ="Breakfast Provider Description")]
        public string BreakfastDescription { get; set; }

        [Required][Display(Name ="Breakfast Provider Street")]
        public string BreakfastStreet { get; set; }

        [Required][Display(Name ="Breakfast Provider City")]
        public string BreakfastCity { get; set; }

        [Display(Name ="Breakfast Provider ZIP")]
        public string BreakfastZIP { get; set; }

        [Display(Name ="Breakfast Provider URL")]
        public string BreakfastLink { get; set; }
    }
}
