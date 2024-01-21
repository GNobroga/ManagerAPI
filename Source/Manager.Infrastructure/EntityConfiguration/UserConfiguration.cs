using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infrastructure.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {   
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(100);

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(100);

            builder.Property(x => x.Password)
                .HasColumnName("password")
                .HasMaxLength(100);
        }
    }
}