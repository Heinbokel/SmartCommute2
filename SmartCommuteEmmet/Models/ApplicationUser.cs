using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SmartCommuteEmmet.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required][Display(Name ="Photo")]
        public string UserPhoto { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(maximumLength: 25,MinimumLength = 2, ErrorMessage ="First name must be between 2 and 25 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 25 characters.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "DOB")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Street")]
        [StringLength(maximumLength: 50, MinimumLength = 4, ErrorMessage ="Street address must be between 4 and 50 characters.")]
        public string UserStreet { get; set; }

        [Display(Name = "City")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "City must be between 1 and 50 characters.")]
        public string UserCity { get; set; }

        [Display(Name = "ZIP")]
        [RegularExpression(@"^(\d{5})$",ErrorMessage ="ZIP must be 5 digits.")]
        public string UserZIP { get; set; }

        [Display(Name = "Date Joined")]
        public DateTime DateRegistered { get; set; }

        [Display(Name ="Biography")]
        public string UserBio { get; set; }

        //FK
        [Required]
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }

    }
}
