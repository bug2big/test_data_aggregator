using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApplication.Infrastructure.Persistence.Entities;

namespace TestWebApplication.Infrastructure.Persistence.EntityConfiguration;
public class Customer2Configuration : IEntityTypeConfiguration<Customer2>
{
    public void Configure(EntityTypeBuilder<Customer2> builder)
    {
        builder.HasNoKey();
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.JobPosition).HasMaxLength(128);
        builder.Property(x => x.Email).HasMaxLength(128);
        builder.Property(x => x.PasswordHash).HasMaxLength(128);
    }
}
