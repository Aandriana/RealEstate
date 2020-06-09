using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.DAL.Configuration;
using RealEstate.DAL.Entities;

namespace RealEstate.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<AgentProperty> AgentProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            modelBuilder.Entity<AgentProperty>()
                .HasKey(ap => new { ap.AgentId, ap.PropertyId });
            modelBuilder.Entity<AgentProperty>()
                .HasOne(ap => ap.Agent)
                .WithMany(u => u.AgentProperties)
                .HasForeignKey(ap => ap.AgentId);
            modelBuilder.Entity<AgentProperty>()
                .HasOne(ap => ap.Property)
                .WithMany(p => p.AgentsProperty)
                .HasForeignKey(ap => ap.PropertyId);
            modelBuilder.ApplyConfiguration(new AgentPropertyConfiguration());
        }
    }
}
