﻿using System;
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
        public string UserAvatar { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Street Address")]
        public string UserStreet { get; set; }

        [Display(Name = "City")]
        public string UserCity { get; set; }

        [Display(Name = "ZIP")]
        public string UserZIP { get; set; }

        [Required]
        public int BusinessId { get; set; }
        [Display(Name = "Business")]
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
