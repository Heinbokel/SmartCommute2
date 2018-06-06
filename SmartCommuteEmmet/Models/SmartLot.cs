using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class SmartLot
    {
        public int Id { get; set; }

        [Required][Display(Name ="Smart Lot Name")][StringLength(maximumLength:20,MinimumLength =2,ErrorMessage ="Smart Lot name must be between 2 and 20 characters.")]
        public string SmartLotName { get; set; }

        [Required][Display(Name ="Smart Lot Description")][StringLength(maximumLength:50,MinimumLength =2,ErrorMessage ="Smart Lot description must be between 2 and 20 characters.")]
        public string SmartLotDescription { get; set; }

        [Required][Display(Name = "Smart Lot Longtitude")][RegularExpression(@"^(\-?\d+(\.\d+)?)",ErrorMessage ="This is not a valid coordinate.")]
        public float SmartLotLongitude { get; set; }

        [Required][Display(Name = "Smart Lot Latitude")][RegularExpression(@"^(\-?\d+(\.\d+)?)",ErrorMessage ="This is not a valid coordinate.")]
        public float SmartLotLatitude { get; set; }
    }
}
