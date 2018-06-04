using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class Business
    {
        public int Id { get; set; }

        public string BusinessName { get; set; }

        public string BusinessDescription { get; set; }

        public string BusinessStreet { get; set; }

        public string BusinessCity { get; set; }

        public string BusinessZIP { get; set; }

        public string BusinessTeamCaptain { get; set; }

        public string BusinessEmail { get; set; }
    }
}
