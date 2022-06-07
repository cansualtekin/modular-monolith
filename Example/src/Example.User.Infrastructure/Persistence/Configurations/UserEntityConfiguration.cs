using Example.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.User.Infrastructure.Persistence.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(75);
            builder.Property(x => x.LastName).HasMaxLength(75);
            builder.Property(x => x.EmailAddress).HasMaxLength(256);
            builder.HasIndex(x => x.EmailAddress);
        }
    }
}
