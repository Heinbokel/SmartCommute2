using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class CommuteDateCurrentYear : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var commute = (Commute)validationContext.ObjectInstance;

            if(commute.CommuteDate.Year == DateTime.Now.Year)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Commutes must be entered for the current year only.");
        }
    }
}
