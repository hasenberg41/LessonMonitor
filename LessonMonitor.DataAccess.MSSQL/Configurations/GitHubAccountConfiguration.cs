using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    internal class GitHubAccountConfiguration : IEntityTypeConfiguration<GitHubAccount>
    {
        public void Configure(EntityTypeBuilder<GitHubAccount> builder)
        {
            builder.HasKey(x => x.MemberId);

            builder.Property(x => x.NickName).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Link).HasMaxLength(1000).IsRequired();

            builder.HasOne(x => x.Member)
                .WithOne(x => x.GitHubAccount)
                .HasForeignKey<GitHubAccount>(x => x.MemberId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
