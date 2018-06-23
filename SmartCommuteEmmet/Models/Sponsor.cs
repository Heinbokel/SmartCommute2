using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class Sponsor
    {
        public int Id { get; set; }

        [Required][Display(Name ="Sponsor Name")][StringLength(maximumLength:20,MinimumLength =2,ErrorMessage="Sponsor name must be between 2 and 20 characters.")]
        public string SponsorName { get; set; }

        [Display(Name ="Sponsor Description")][StringLength(maximumLength:50,MinimumLength =2,ErrorMessage="Sponsor description must be between 2 and 50 characters.")]
        public string SponsorDescription { get; set; }

        [Required][Display(Name ="Sponsor Link")]
        public string SponsorLink { get; set; }

        [Display(Name ="Sponsor Image")]
        public string SponsorImagePath { get; set; }
    }
}
