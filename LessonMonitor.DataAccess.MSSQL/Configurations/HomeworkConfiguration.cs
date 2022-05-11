﻿using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Link).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(2000);

            builder.HasOne(x => x.Lesson)
                .WithOne(x => x.Homework)
                .HasForeignKey<Lesson>(x => x.HomeworkId)
                .HasPrincipalKey<Homework>(x => x.LessonId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
