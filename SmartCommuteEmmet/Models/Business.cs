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
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]

        public string BusinessName { get; set; }

        [Display(Name ="Business Description")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Description must be between 2 and 100 characters.")]

        public string BusinessDescription { get; set; }

        [Display(Name = "Business Street Address")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Street must be between 2 and 100 characters.")]

        public string BusinessStreet { get; set; }

        [Display(Name = "Business City")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "City must be between 2 and 100 characters.")]
        public string BusinessCity { get; set; }

        [Display(Name = "Business ZIP")]
        [RegularExpression(@"^(\d{5})$", ErrorMessage = "ZIP must be 5 digits.")]
        public string BusinessZIP { get; set; }

    }
}
