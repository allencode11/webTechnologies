using System.ComponentModel.DataAnnotations;


namespace tehnologiiWeb.Domain
{
    public class Item
    {
        [Key]
        public int  id { get; set; }

        public string name { set; get; }

        public string category { set; get; }

        public float price { get; set; }

        public string owner { get; set; }

        [EmailAddress]
        public string email { get; set; }
    }
}
