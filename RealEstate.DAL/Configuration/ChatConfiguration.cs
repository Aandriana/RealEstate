using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.DAL.Entities;

namespace RealEstate.DAL.Configuration
{
    class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable("Chat");
            builder.HasKey(c => c.Id);
            builder
                .HasMany(c => c.Participants)
                .WithOne(c => c.Chat)
                .HasForeignKey(c => c.ChatId);
            builder
                .HasMany(c => c.Messages)
                .WithOne(c => c.Chat)
                .HasForeignKey(c => c.ChatId);

        }
    }
}
