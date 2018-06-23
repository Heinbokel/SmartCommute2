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
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Breakfast name must be between 2 and 50 characters.")]
        public string BreakfastName { get; set; }

        [Display(Name ="Breakfast Provider Description/Time")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Breakfast description must be between 2 and 100 characters.")]
        public string BreakfastDescription { get; set; }

        [Required][Display(Name ="Breakfast Provider Street")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Street must be between 2 and 100 characters.")]
        public string BreakfastStreet { get; set; }

        [Required][Display(Name ="Breakfast Provider City")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "City must be between 2 and 100 characters.")]
        public string BreakfastCity { get; set; }

        [Display(Name ="Breakfast Provider ZIP")]
        [RegularExpression(@"^(\d{5})$", ErrorMessage = "ZIP must be 5 digits.")]
        public string BreakfastZIP { get; set; }

        [Display(Name ="Breakfast Provider URL")]
        public string BreakfastLink { get; set; }
    }
}
