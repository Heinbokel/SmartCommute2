using System.ComponentModel.DataAnnotations;

namespace SmartCommuteEmmet.Models
{
    public class EndPoint
    {
        public int Id { get; set; }

        [Required][Display(Name ="End Point Name")][StringLength(maximumLength:100,MinimumLength =2,ErrorMessage ="End Point name must be between 2 and 100 characters.")]
        public string EndPointName { get; set; }

        [Display(Name ="End Point Description")][StringLength(maximumLength:200,MinimumLength =2,ErrorMessage ="End Point description must be between 2 and 200 characters.")]
        public string EndPointDescription { get; set; }

        [Display(Name = "End Point Longitude")][RegularExpression(@"^(\-?\d+(\.\d+)?)",ErrorMessage ="This is not a valid coordinate.")]
        public float? EndPointLongitude { get; set; }

        [Display(Name = "End Point Latitude")][RegularExpression(@"^(\-?\d+(\.\d+)?)",ErrorMessage ="This is not a valid coordinate.")]
        public float? EndPointLatitude { get; set; }

        public string UserId { get; set; }
    }
}