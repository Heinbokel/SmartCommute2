using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public string RewardName { get; set; }
        public string RewardDescription { get; set; }
        public int RequiredCommutes { get; set; }
        public int RequiredMiles { get; set; }

        //FK
        public int DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public Document RewardDocument { get; set; }
    }
}
