// <auto-generated />
using System;
using LessonMonitor.DataAccess.MSSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LessonMonitor.DataAccess.MSSQL.Migrations
{
    [DbContext(typeof(LessonMonitorDbContext))]
    [Migration("20220508182733_UpdateMembers_AddAltKeyYoutubeAccounts")]
    partial class UpdateMembers_AddAltKeyYoutubeAccounts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LessonMonitor.DataAccess.MSSQL.Entities.GitHubAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasAlternateKey("MemberId");

                    b.ToTable("GitHubAccounts");
                });

            modelBuilder.Entity("LessonMonitor.DataAccess.MSSQL.Entities.Homework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Homeworks");
                });

            modelBuilder.Entity("LessonMonitor.DataAccess.MSSQL.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("HomeworkId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("HomeworkId")
                        .IsUnique()
                        .HasFilter("[HomeworkId] IS NOT NULL");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("LessonMonitor.DataAccess.MSSQL.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("GitHubAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("YoutubeAccountId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasAlternateKey("YoutubeAccountId");

                    b.HasIndex("GitHubAccountId")
                        .IsUnique()
                        .HasFilter("[GitHubAccountId] IS NOT NULL");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("LessonMonitor.DataAccess.MSSQL.Entities.Homework", b =>
                {
                    b.HasOne("LessonMonitor.DataAccess.MSSQL.Entities.Member", null)
                        .WithMany("Homeworks")
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("LessonMonitor.DataAccess.MSSQL.Entities.Lesson", b =>
                {
                    b.HasOne("LessonMonitor.DataAccess.MSSQL.Entities.Homework", "Homework")
                        .WithOne("Lesson")
                        .HasForeignKey("LessonMonitor.DataAccess.MSSQL.Entities.Lesson", "HomeworkId")
                        .HasPrincipalKey("LessonMonitor.DataAccess.MSSQL.Entities.Homework", "LessonId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Homework");
                });

            modelBuilder.Entity("LessonMonitor.DataAccess.MSSQL.Entities.Member", b =>
                {
                    b.HasOne("LessonMonitor.DataAccess.MSSQL.Entities.GitHubAccount", "GitHubAccount")
                        .WithOne("Member")
                        .HasForeignKey("LessonMonitor.DataAccess.MSSQL.Entities.Member", "GitHubAccountId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("GitHubAccount");
                });

            modelBuilder.Entity("LessonMonitor.DataAccess.MSSQL.Entities.GitHubAccount", b =>
                {
                    b.Navigation("Member");
                });

            modelBuilder.Entity("LessonMonitor.DataAccess.MSSQL.Entities.Homework", b =>
                {
                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("LessonMonitor.DataAccess.MSSQL.Entities.Member", b =>
                {
                    b.Navigation("Homeworks");
                });
#pragma warning restore 612, 618
        }
    }
}
