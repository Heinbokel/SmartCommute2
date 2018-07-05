using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models.HomeViewModels
{
    public class HomeViewModel
    {
        public ConfigDate ConfigDate { get; set; }

        public string CarouselSponsorImagePath { get; set; }

        public float TotalDistance { get; set; }
        public int TotalCommutes { get; set; }
        public float GasSaved { get; set;}
        public float CarbonReduced { get; set; }
    }
}
