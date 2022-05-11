using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    internal class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
         {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.YoutubeUserId);

            builder.Property(x => x.Name)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.YoutubeUserId)
                .HasMaxLength(200);
        }
    }
}
