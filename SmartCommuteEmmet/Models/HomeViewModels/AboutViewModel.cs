using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models.HomeViewModels
{
    public class AboutViewModel
    {
        public List<Sponsor> Sponsors { get; set; }
        public List<Breakfast> Breakfasts { get; set; }
    }
}
