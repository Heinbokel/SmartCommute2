﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models.CommuteViewModels
{
    public class SavedCommuteViewModel
    {
        [Required]
        [Display(Name = "Distance (round trip)")]
        [Range(1, 20, ErrorMessage = "Distance must be between 1 and 20 miles")]
        public int CommuteDistance { get; set; }

        [Display(Name = "Description")]
        public string CommuteDescription { get; set; }

        [Required]
        [Display(Name = "Commute Name")]
        public string CommuteName { get; set; }

        public string UserId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int? StartPointId { get; set; }
        [Required]
        [ForeignKey("StartPointId")]
        [Display(Name = "Starting Point")]
        public StartPoint StartPoint { get; set; }

        public int? EndPointId { get; set; }
        [Required]
        [ForeignKey("EndPointId")]
        [Display(Name = "Ending Point")]
        public EndPoint EndPoint { get; set; }
    }
}
