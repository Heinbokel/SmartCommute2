using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class CommuteType
    {
        public int Id { get; set; }

        [Required][Display(Name ="Commute Type Name")][StringLength(maximumLength:25,MinimumLength =2,ErrorMessage ="Name must be between 2 and 25 characters.")]
        public string CommuteTypeName { get; set; }

        [Required][Display(Name ="Points Awarded")][Range(1,10,ErrorMessage ="Points awarded must be between 1 and 10.")]
        public int CommutePointsAwarded { get; set; }

        [Required][Display(Name ="Commute Type Description")][StringLength(maximumLength:50,MinimumLength =2,ErrorMessage ="Name must be between 2 and 50 characters.")]
        public string CommuteTypeDescription { get; set; }
    }
}
