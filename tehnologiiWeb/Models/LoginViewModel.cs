using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tehnologiiWeb.Web.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        public bool RememberMe { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; } = "User";

        public string ReturnURL { get; set; } = "/";
    }
}
