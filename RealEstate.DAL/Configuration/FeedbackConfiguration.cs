using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.DAL.Entities;

namespace RealEstate.DAL.Configuration
{
    class FeedbackConfiguration: IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks");
            builder.HasKey(f => f.Id);
            builder.HasOne(f => f.Agent).WithMany(a => a.Feedbacks).HasForeignKey(f => f.AgentId);
            builder.HasOne(f => f.User).WithMany(u => u.Feedbacks).HasForeignKey(f => f.UserId);
        }
    }
}
