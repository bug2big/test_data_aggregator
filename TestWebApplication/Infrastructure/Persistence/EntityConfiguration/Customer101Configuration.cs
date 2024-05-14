using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApplication.Infrastructure.Persistence.Entities;

namespace TestWebApplication.Infrastructure.Persistence.EntityConfiguration;
public class Customer101Configuration : IEntityTypeConfiguration<Customer101>
{
    public void Configure(EntityTypeBuilder<Customer101> builder)
    {
        builder.HasNoKey();
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(128);
        builder.Property(x => x.Salutation).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(128);
    }
}
