using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class ConfigDate
    {
        public int Id { get; set; }
        public string ConfigDateName { get; set; }
        public string ConfigDateDescription { get; set; }
        public DateTime ConfigDateDate { get; set; }
    }
}
