using First.Models;
using Microsoft.EntityFrameworkCore;

namespace First.Contexts
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext>options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Command>Commands { get; set; }
    }
}
