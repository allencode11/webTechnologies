using System.ComponentModel.DataAnnotations;

namespace tehnologiiWeb.Domain
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(15)]
        public string Username { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(31)]
        public string FullName { get; set; }

        public string Password { get; set; }


    }
}
