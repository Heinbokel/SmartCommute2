using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models.LeaderboardViewModels
{
    public class LeaderboardViewModel
    {
        [Display(Name ="Commuter")]
        public string UserName { get; set; }

        public string UserPhoto { get; set; }

        public string UserId { get; set; }

        [Display(Name="Commutes")]
        public int TotalCommutes { get; set; }

        [Display(Name = "Distance")]
        public int TotalDistance { get; set; }

        [Display(Name = "Bikes")]
        public int BikeCommutes { get; set; }

        [Display(Name = "Runs")]
        public int RunCommutes { get; set; }

        [Display(Name = "Carpools")]
        public int CarpoolCommutes { get; set; }
    }
}
