using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models.LeaderboardViewModels
{
    public class LeaderboardViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<Commute> Commutes { get; set; }
    }
}
