using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class CommuteType
    {
        public int Id { get; set; }

        public string CommuteName { get; set; }

        public int CommutePointsAwarded { get; set; }

        public string CommuteDescription { get; set; }
    }
}
