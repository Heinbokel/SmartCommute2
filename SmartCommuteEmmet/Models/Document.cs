using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCommuteEmmet.Models
{
    public class Document
    {
        public int Id { get; set; }

        [Required][Display(Name ="Document Name")][StringLength(maximumLength:50, MinimumLength =2, ErrorMessage ="Document name must be between 2 and 50 characters.")]
        public string DocumentName { get; set; }

        [Required][Display(Name ="Document Description")][StringLength(maximumLength:200, MinimumLength =2, ErrorMessage ="Document description must be between 2 and 200 characters.")]
        public string DocumentDescription { get; set; }

        [Display(Name ="Document File")]
        public string DocumentFilePath { get; set; }
    }
}
