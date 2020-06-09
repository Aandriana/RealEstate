using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.DAL.Entities;

namespace RealEstate.DAL.Configuration
{
    class AgentPropertyConfiguration: IEntityTypeConfiguration<AgentProperty>
    {
        public void Configure (EntityTypeBuilder<AgentProperty> builder)
        {
            builder.ToTable("AgentsProperties");
        }
    }
}
