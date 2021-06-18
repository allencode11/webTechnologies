using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tehnologiiWeb.Web.Models
{
    public class ItemsViewModel
    {
        public int? Id { get; set; }

        public string Name { set; get; }

        public string Category { set; get; }

        public float Price { get; set; }

        public string Owner { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string StringUrl { get; set; }
    }
}
