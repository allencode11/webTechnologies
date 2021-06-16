using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using tehnologiiWeb.Domain;

namespace tehnologiiWeb.DataAccess
{
    public class _DbContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;
        public _DbContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Account> accounts { get; set; }
        public DbSet<Item> items { get; set; }
    }


}
