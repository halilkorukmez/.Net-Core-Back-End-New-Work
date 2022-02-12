using Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(a => a.UserName)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(a => a.Password)
                .HasMaxLength(15)
                .IsRequired(true);

            builder.Property(a => a.IsActive)
                .IsRequired(true);
        }
    }
}