using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using tehnologiiWeb.Domain;

namespace tehnologiiWeb.DataAccess
{
    public class _DbContext : IdentityDbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        {

        }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Item> items { get; set; }
    }


}
