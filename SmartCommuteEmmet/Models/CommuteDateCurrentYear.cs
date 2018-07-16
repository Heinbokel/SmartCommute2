using SmartCommuteEmmet.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SmartCommuteEmmet.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartCommuteEmmet.Models
{
    public class CommuteDateCurrentYear : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ApplicationDbContext _context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            var commute = (Commute)validationContext.ObjectInstance;
            DateTime startDate = _context.ConfigDate.Select(c => c.StartDate).FirstOrDefault();
            DateTime endDate = _context.ConfigDate.Select(c => c.EndDate).FirstOrDefault();
            string errorMessage = "Commute date must be between " + startDate.ToShortDateString() + " and " + endDate.ToShortDateString() + ".";

            if (commute.CommuteDate >= startDate && commute.CommuteDate <= endDate)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(errorMessage);
        }
    }
}
