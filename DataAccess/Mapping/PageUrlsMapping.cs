using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.PageUrls;

namespace DataAccess.Mapping
{
    public class PageUrlsMapping : IEntityTypeConfiguration<PageUrl>
    {
        public void Configure(EntityTypeBuilder<PageUrl> builder)
        {
            builder.ToTable("PageUrls");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.UrlName)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(a => a.UrlAddress)
                .IsRequired(true);
            
            builder.Property(a => a.IsActive)
                .IsRequired(true);

            builder.Property(a => a.UserId)
                .IsRequired(true);
        }
    }
}
