using API_CRUD.Infrastructure.SeedData;
using API_CRUD.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategorySeeding());
            modelBuilder.ApplyConfiguration(new AppUserSeeding());
            base.OnModelCreating(modelBuilder);
        }
    }
}
