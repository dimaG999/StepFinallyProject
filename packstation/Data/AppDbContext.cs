using Microsoft.EntityFrameworkCore;
using packstation.Data.Configs;
using packstation.Entities;

namespace packstation.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<ParcelCategory> ParcelCategories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ParcelConfiguration());
            modelBuilder.ApplyConfiguration(new ParcelCategoryConfiguration());
        }
    }
}
    

