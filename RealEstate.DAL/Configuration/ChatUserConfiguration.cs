using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.DAL.Entities;

namespace RealEstate.DAL.Configuration
{
    public class ChatUserConfiguration : IEntityTypeConfiguration<ChatUser>
    {
        public void Configure(EntityTypeBuilder<ChatUser> builder)
        {
            builder.ToTable("ChatUser");
            builder.HasKey(c => c.Id);
            builder
                .HasOne(c => c.User)
                .WithMany(u => u.Chats)
                .HasForeignKey(c => c.UserId);
        }
    }
}
