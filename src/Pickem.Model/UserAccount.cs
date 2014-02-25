using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Pickem.Model
{
    public class UserAccount:IdentityUser
    {
        public UserAccount()
        {
            
        }
        public DateTime CreateDate { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "E-mail Address")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
