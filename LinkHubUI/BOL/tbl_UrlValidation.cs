using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class UniqueUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LinkHubDbEntities db = new LinkHubDbEntities();
            int count = db.tbl_Url.ToList().Where(u => u.Url.Equals(value)).Count();
            if (count != 0 || value == null)
                return new ValidationResult("Url already exist.");
            return ValidationResult.Success;
        }
    }
    public class tbl_UrlValidation
    {
        [Required]
        [Url]
        //[UniqueUrl]
        public string Url { get; set; }
        [Required]
        public string UrlTitle { get; set; }
        [Required]
        public string UrlDesc { get; set; }
    }
    [MetadataType(typeof(tbl_UrlValidation))]
    public partial class tbl_Url
    {

    }
}
