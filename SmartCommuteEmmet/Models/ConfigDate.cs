using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class ConfigDate
    {
        public int Id { get; set; }

        [Required][Display(Name ="Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required][Display(Name ="End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required][Display(Name ="Register By Date")]
        [DataType(DataType.Date)]
        public DateTime RegisterByDate { get; set; }
    }
}
