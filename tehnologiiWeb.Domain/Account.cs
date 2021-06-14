using System.ComponentModel.DataAnnotations;

namespace tehnologiiWeb.Domain
{
    public class Account
    {
        [Key]
        public int id { get; set; }
        [MaxLength(15)]
        public string username { get; set; }
        [MaxLength(15)]
        [RegularExpression(@"^(?=.*[a - z])(?=.*[A - Z])(?=.*\d).{8,}$", ErrorMessage = "Restrictions are not respected!" +
                                                                                        "Should have at least one lower case!" +
                                                                                        "Should have at least one upper case!" +
                                                                                        "Minimum 8 characters")]
        public string password { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [MaxLength(31)]
        public string fullName { get; set; }

    }
}
