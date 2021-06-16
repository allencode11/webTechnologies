using System.ComponentModel.DataAnnotations;

namespace tehnologiiWeb.Domain
{
    public class Account
    {
        [Key]
        public int id { get; set; }
        [MaxLength(15)]
        public string username { get; set; }
        
        [EmailAddress]
        public string email { get; set; }
        [MaxLength(31)]
        public string fullName { get; set; }
        public  bool rememberMe { get; set; }

        [MaxLength(15)]
        [RegularExpression(@"^(?=.*[a - z])(?=.*[A - Z])(?=.*\d).{8,}$", ErrorMessage = "Restrictions are not respected!" +
                                                                                        "Should have at least one lower case!" +
                                                                                        "Should have at least one upper case!" +
                                                                                        "Minimum 8 characters")]
        [DataType(DataType.Password)] 
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("password", ErrorMessage = "Password and confirmation password not match.")]
        public string confirmPassword { get; set; }

    }
}
