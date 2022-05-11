using LessonMonitor.DataAccess.MSSQL.Configurations;
using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LessonMonitor.DataAccess.MSSQL
{
    public class LessonMonitorDbContext : DbContext
    {
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<GitHubAccount> GitHubAccounts { get; set; }
        public LessonMonitorDbContext(DbContextOptions<LessonMonitorDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HomeworkConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new GitHubAccountConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
