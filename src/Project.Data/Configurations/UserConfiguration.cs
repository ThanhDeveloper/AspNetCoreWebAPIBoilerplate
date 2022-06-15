using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Entities;

namespace Project.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DisplayName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(p => p.StoredSalt).IsRequired();

            builder.ToTable("Users");
        }
    }
}
