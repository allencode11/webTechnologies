using System.ComponentModel.DataAnnotations;


namespace tehnologiiWeb.Domain
{
    public class Item
    {
        [Key]
        public int  Id { get; set; }

        public string Name { set; get; }

        public string Category { set; get; }

        public float Price { get; set; }

        public string Owner { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string StringUrl { get; set; }

    }
}
