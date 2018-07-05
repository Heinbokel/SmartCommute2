using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class Commute
    {
        public int Id { get; set; }

        [Required][Display(Name ="Distance (round trip)")][Range(1,20,ErrorMessage ="Distance must be between 1 and 20 miles")]
        public int CommuteDistance { get; set; }

        [Display(Name ="Description")]
        public string CommuteDescription { get; set; }

        [Display(Name = "Save for future trips?")]
        public bool CommuteSaved { get; set; }

        [Required][Display(Name ="Commute Name")]
        public string CommuteName { get; set; }

        [Required][Display(Name ="Commute Date")]
        [DataType(DataType.Date)]
        public DateTime CommuteDate { get; set; }

        //FK
        public int CommuteTypeId { get; set; }
        [ForeignKey("CommuteTypeId")][Display(Name ="Commute Type")]
        public virtual CommuteType CommuteType { get; set; }

        public int? StartPointId { get; set; }
        [ForeignKey("StartPointId")][Display(Name ="Starting Point")]
        public virtual StartPoint StartPoint { get; set; }

        [Display(Name ="Custom Start Point")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Start Point name must be between 2 and 50 characters.")]
        public string StartPointCustom { get; set; }

        public int? EndPointId { get; set; }
        [ForeignKey("EndPointId")][Display(Name ="Ending Point")]
        public EndPoint EndPoint { get; set; }

        [Display(Name = "Custom End Point")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "End Point name must be between 2 and 50 characters.")]
        public string EndPointCustom { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
