using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var userCount = (new LinkHubDbEntities()).tbl_User.ToList().Where(u => u.UserEmail.Equals(value)).Count();
            if (userCount > 0)
                return new ValidationResult("User email already exist.");
            return ValidationResult.Success;
        }
    }
    public class tbl_UserValidation
    {
        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
    [MetadataType(typeof(tbl_UserValidation))]
    public partial class tbl_User
    {
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
