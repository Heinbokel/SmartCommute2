using System.ComponentModel.DataAnnotations;

namespace SmartCommuteEmmet.Models
{
    public class StartPoint
    {
        public int Id { get; set; }

        [Required][Display(Name ="Start Point Name")][StringLength(maximumLength:25,MinimumLength =2,ErrorMessage ="Start Point name must be between 2 and 25 characters.")]
        public string StartPointName { get; set; }

        [Display(Name ="Start Point Description")][StringLength(maximumLength:50,MinimumLength =2,ErrorMessage ="Start Point description must be between 2 and 50 characters.")]
        public string StartPointDescription { get; set; }

        [Display(Name = "Start Point Longitude")][RegularExpression(@"^(\-?\d+(\.\d+)?)",ErrorMessage ="This is not a valid coordinate.")]
        public float? StartPointLongitude { get; set; }

        [Display(Name = "Start Point Latitude")][RegularExpression(@"^(\-?\d+(\.\d+)?)",ErrorMessage ="This is not a valid coordinate.")]
        public float? StartPointLatitude { get; set; }

        public string UserId { get; set; }
    }
}