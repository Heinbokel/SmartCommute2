using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Display(Name ="Profile Picture")]
        public string UserPhoto { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 25 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 25 characters.")]
        [Display(Name = "Last Name")]
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

        [Display(Name ="Biography")][StringLength(maximumLength:500,ErrorMessage ="Biography must be less than 500 characters.")]
        public string UserBio { get; set; }

        [Required]
        [Display(Name = "Business")]
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
