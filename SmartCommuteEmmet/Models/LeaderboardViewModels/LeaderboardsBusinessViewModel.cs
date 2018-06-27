using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models.LeaderboardViewModels
{
    public class LeaderboardsBusinessViewModel
    {
        [Display(Name ="Business")]
        public string BusinessName { get; set; }

        [Display(Name ="Team Size")]
        public int TeamSize { get; set; }

        public int BusinessId { get; set; }

        [Display(Name = "Distance")]
        public int TotalDistance { get; set; }

        [Display(Name = "Commutes")]
        public int TotalCommutes { get; set; }

        [Display(Name = "Bikes")]
        public int TotalBikes { get; set; }

        [Display(Name = "Runs")]
        public int TotalRuns { get; set; }

        [Display(Name = "Car Pools")]
        public int TotalCarpools { get; set; }
    }
}
