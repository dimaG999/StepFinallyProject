namespace packstation.Data.Configs
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using packstation.Entities;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            
            builder.HasKey(u => u.Id);

            
            builder.Property(u => u.UserName).HasMaxLength(100).IsRequired();
            builder.Property(u => u.UserLastName).HasMaxLength(100).IsRequired();
            builder.Property(u => u.PasswordHash)
       .IsRequired();


            
        }
    }
}
