using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCommuteEmmet.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //[Required]
        //[Display(Name = "Profile Picture")]
        //public string UserPhoto { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 25 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 25 characters.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Street Address")]
        [StringLength(maximumLength: 50, MinimumLength = 4, ErrorMessage = "Street address must be between 4 and 50 characters.")]
        public string UserStreet { get; set; }

        [Display(Name = "City")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "City must be between 1 and 50 characters.")]
        public string UserCity { get; set; }

        [Display(Name = "ZIP")]
        [RegularExpression(@"^(\d{5})$", ErrorMessage = "ZIP must be 5 digits.")]
        public string UserZIP { get; set; }

        [Display(Name = "Biography")]
        [StringLength(maximumLength: 500, ErrorMessage = "Biography must be less than 500 characters.")]
        public string UserBio { get; set; }

        //FK
        [Required]
        [Display(Name = "Business")]
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }


        public string StatusMessage { get; set; }
    }
}
