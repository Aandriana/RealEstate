using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.DAL.Entities;

namespace RealEstate.DAL.Configuration
{
    class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UsersProfiles");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).HasMaxLength(32);
            builder.Property(u => u.LastName).HasMaxLength(32);
            builder.Property(u => u.City).HasMaxLength(32);
            builder.HasOne(u => u.User).WithOne().HasForeignKey<UserProfile>(u => u.Id);
        }
    }
}
