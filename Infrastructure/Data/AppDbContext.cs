using ConstructionProjectManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConstructionProjectManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ConstructionProject> ConstructionProjects { get; set; }
        public DbSet<Users> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ConstructionProject>()
                .HasKey(p => p.ProjectId); 

            modelBuilder.Entity<ConstructionProject>()
                .HasOne<Users>() 
                .WithMany() 
                .HasForeignKey(p => p.CreatorId); 
        }
    }
}
