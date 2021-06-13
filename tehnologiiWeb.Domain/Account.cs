using System.ComponentModel.DataAnnotations;

namespace tehnologiiWeb.Domain
{
    class Account
    {
        public string Username{ get; set; }
        public string  Password { get; set; }
        public int Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }

    }
}
