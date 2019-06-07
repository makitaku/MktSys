using Microsoft.EntityFrameworkCore;
using MktSys.Models;

namespace QuickMaster.Models
{
    public class NpgContext : DbContext
    {
        public NpgContext(DbContextOptions<NpgContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<WorkType> WorkType { get; set; }
        public DbSet<DailyReport> DailyReport { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Project>()
        //        .HasKey(c => new { c.MainNo, c.SubNo });
        //}
    }
}
