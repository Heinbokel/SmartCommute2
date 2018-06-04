using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string SponsorName { get; set; }
        public string SponsorDescription { get; set; }
        public string SponsorLink { get; set; }
        public string SponsorImagePath { get; set; }
    }
}
