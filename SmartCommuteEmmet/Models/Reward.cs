using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class Reward
    {
        public int Id { get; set; }

        [Required][Display(Name ="Reward Name")][StringLength(maximumLength:20,MinimumLength =2,ErrorMessage ="Reward name must be between 2 and 20 characters.")]
        public string RewardName { get; set; }

        [Required][Display(Name ="Reward Description")][StringLength(maximumLength:50,MinimumLength =2,ErrorMessage ="Reward description must be between 2 and 50 characters.")]
        public string RewardDescription { get; set; }

        [Required][Display(Name ="Commutes Required")][Range(1,1000000,ErrorMessage ="Commutes required must be greater than 0.")]
        public int RequiredCommutes { get; set; }

        [Required][Display(Name ="Miles Required")][Range(1,1000000,ErrorMessage ="Miles required must be greater than 0.")]
        public int RequiredMiles { get; set; }
    }
}
