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
            builder.Property(f => f.Text).HasMaxLength(200);
            builder.Property(f => f.Date).IsRequired();
            builder
                 .HasOne(f => f.ReceiverProfile)
                 .WithOne(u => u.FeedbackForMe)
                 .HasForeignKey<Feedback>(f => f.ReceiverId);
            builder
                .HasOne(f => f.SenderProfile)
                .WithOne(u => u.IWroteFeedback)
                .HasForeignKey<Feedback>(f => f.SenderId);
        }
    }
}
