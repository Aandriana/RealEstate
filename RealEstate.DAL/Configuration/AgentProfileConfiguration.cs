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
            builder.HasKey(a => a.Id);
            builder
                .HasOne(a => a.User)
                .WithOne(u => u.AgentPrifile)
                .HasForeignKey<AgentProfile>(a => a.UserId);
        }
    }
}
