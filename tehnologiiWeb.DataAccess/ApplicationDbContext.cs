using Microsoft.EntityFrameworkCore;
using tehnologiiWeb.Domain;

namespace tehnologiiWeb.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Account> accounts { get; set; }
        public DbSet<Item> items { get; set; }
    }


}
