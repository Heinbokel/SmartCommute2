using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class CarouselSponsorImage
    {
        public int Id { get; set; }

        [Display(Name ="Image")]
        public string CarouselImagePath { get; set; }

        [Required][Display(Name ="Date Modified")]
        public DateTime DateUploaded { get; set; }
    }
}
