using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class Commute
    {
        public int Id { get; set; }
        public int CommuteDistance { get; set; }
        public string CommuteDescription { get; set; }
        public bool CommuteSaved { get; set; }
        public string CommuteName { get; set; }
        public DateTime CommuteDate { get; set; }

        //FK
        public int CommuteTypeId { get; set; }
        [ForeignKey("CommuteTypeId")]
        public CommuteType CommuteType { get; set; }

        public int PointId { get; set; }
        [ForeignKey("PointId")]
        public Point StartPoint { get; set; }

        //add end point here

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
