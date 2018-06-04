using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class SmartLot
    {
        public int Id { get; set; }
        public string SmartLotName { get; set; }
        public string SmartLotDescription { get; set; }
        public float SmartLotLongitude { get; set; }
        public float SmartLotLatitude { get; set; }
    }
}
