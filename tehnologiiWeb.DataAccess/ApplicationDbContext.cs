using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using tehnologiiWeb.Domain;

namespace tehnologiiWeb.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }

        public DbSet<Account> accounts { get; set; }
        public DbSet<Item> items { get; set; }
    }


}
