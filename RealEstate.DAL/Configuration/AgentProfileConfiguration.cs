using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.DAL.Entities;

namespace RealEstate.DAL.Configuration
{
    class AgentProfileConfiguration : IEntityTypeConfiguration<AgentProfile>
    {
        public void Configure(EntityTypeBuilder<AgentProfile> builder)
        {
            builder.ToTable("AgentProfile");
            builder.HasKey(o => o.Id);
            builder
                .HasOne(a => a.User)
                .WithOne(u => u.AgentProfile)
                .HasForeignKey<AgentProfile>(a => a.UserId);
        }
    }
}
