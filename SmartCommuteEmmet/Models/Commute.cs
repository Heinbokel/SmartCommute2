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

        public int StartPointId { get; set; }
        [ForeignKey("StartPointId")]
        public StartPoint StartPoint { get; set; }

        public int EndPointId { get; set; }
        [ForeignKey("EndPointId")]
        public EndPoint EndPoint { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
