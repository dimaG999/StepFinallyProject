namespace packstation.Data.Configs
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using packstation.Entities;

    public class ParcelCategoryConfiguration : IEntityTypeConfiguration<ParcelCategory>
    {
        public void Configure(EntityTypeBuilder<ParcelCategory> builder)
        {
          
            builder.HasKey(c => c.Id);

            
            builder.Property(c => c.CategoryName)
                   .HasMaxLength(100)
                   .IsRequired();

           
            builder.HasMany(c => c.Parcels)
                   .WithOne(p => p.ParcelCategory)
                   .HasForeignKey(p => p.ParcelCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
