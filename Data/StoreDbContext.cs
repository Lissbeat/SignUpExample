
using assignment_5.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment_5.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options){}

        public DbSet<Signup> Event { get; set; }

    }
}