using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tehnologiiWeb.Web.Models
{
    public class RegisterViewModel
    {
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(31)]
        public string FullName { get; set; }

        [MaxLength(15)]
        [RegularExpression(@"^(?=.*[a - z])(?=.*[A - Z])(?=.*\d).{8,}$", ErrorMessage = "Restrictions are not respected!" +
                                                                                        "Should have at least one lower case!" +
                                                                                        "one upper case!" +
                                                                                     "and minimum 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }
    }
}
