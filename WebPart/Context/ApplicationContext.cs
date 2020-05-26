using DataBase;
using Microsoft.EntityFrameworkCore;

namespace WebPart.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Result> Results { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>().HasData(
                new Result[]
                {
                new Result { Id=1, Input="First", Width=10 , Output="first"},
                new Result { Id=2, Input="Second", Width=10 , Output="Second"},
                new Result { Id=3, Input="Second", Width=10 , Output="Second"}
                });
        }
    }
}
