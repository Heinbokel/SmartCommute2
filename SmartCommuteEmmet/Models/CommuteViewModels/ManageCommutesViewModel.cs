using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models.CommuteViewModels
{
    public class ManageCommutesViewModel
    {
        public string UserName { get; set; }
        public string BusinessName { get; set; }
        public string CommuteType { get; set; }
        public int CommuteDistance { get; set; }
        public string CommuteName { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }

    }
}
