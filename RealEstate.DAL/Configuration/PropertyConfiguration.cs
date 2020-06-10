using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.DAL.Entities;

namespace RealEstate.DAL.Configuration
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Properties");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.User).WithMany(u => u.Properties).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.Agent).WithMany(a => a.Properties).HasForeignKey(p => p.AgentId);
        }   
    }
}
