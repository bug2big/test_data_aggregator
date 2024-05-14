using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApplication.Infrastructure.Persistence.Entities;

namespace TestWebApplication.Infrastructure.Persistence.EntityConfiguration;
public class NotificationsBrokerConfiguration : IEntityTypeConfiguration<NotificationsBroker>
{
    public void Configure(EntityTypeBuilder<NotificationsBroker> builder)
    {
        builder.HasNoKey();
        builder.Property(x => x.Email).IsRequired().HasMaxLength(128);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(128);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(128);
        builder.Property(x => x.FinHash).HasMaxLength(128);
    }
}
