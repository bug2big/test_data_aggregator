using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApplication.Infrastructure.Persistence.Entities;

namespace TestWebApplication.Infrastructure.Persistence.EntityConfiguration;
public class Customer145Configuration : IEntityTypeConfiguration<Customer145>
{
    public void Configure(EntityTypeBuilder<Customer145> builder)
    {
        builder.HasNoKey();
        builder.Property(x => x.UserId).HasMaxLength(128);
        builder.Property(x => x.Name).HasMaxLength(128);
        builder.Property(x => x.Email).HasMaxLength(128);
        builder.Property(x => x.Password).HasMaxLength(128);
    }
}
