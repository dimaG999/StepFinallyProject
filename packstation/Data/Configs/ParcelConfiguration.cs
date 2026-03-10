namespace packstation.Data.Configs
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using packstation.Entities;

    public class ParcelConfiguration : IEntityTypeConfiguration<Parcel>
    {
        public void Configure(EntityTypeBuilder<Parcel> builder)
        {
            
            builder.HasKey(p => p.Id);

            
            builder.HasOne(p => p.User)
                   .WithMany(u => u.SentParcels)
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            
            

            
            builder.HasOne(p => p.ParcelCategory)
                   .WithMany()
                   .HasForeignKey(p => p.ParcelCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
