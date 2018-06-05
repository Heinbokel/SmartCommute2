﻿using System;
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
        [Required][StringLength(maximumLength: 25,MinimumLength = 2, ErrorMessage ="First name must be between 2 and 25 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 25 characters.")]
        public string LastName { get; set; }

        [Required]//Do custom attribute to ensure date is between 120 years ago and 14 years ago.
        public DateTime DateOfBirth { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 4, ErrorMessage ="Street address must be between 4 and 50 characters.")]
        public string UserStreet { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "City must be between 2 and 50 characters.")]
        public string UserCity { get; set; }

        [RegularExpression(@"^(\d{5})$",ErrorMessage ="ZIP must be 5 digits.")]
        public string UserZIP { get; set; }

        //FK
        [Required]
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }

    }
}