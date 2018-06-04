using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class Breakfast
    {
        public int Id { get; set; }
        public string BreakfastName { get; set; }
        public string BreakfastDescription { get; set; }
        public string BreakfastStreet { get; set; }
        public string BreakfastCity { get; set; }
        public string BreakfastZIP { get; set; }
        public string BreakfastLink { get; set; }

        //FK
        public Document BreakfastDocument { get; set; }
    }
}
