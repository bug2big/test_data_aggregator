using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApplication.Infrastructure.Persistence.Entities;

namespace TestWebApplication.Infrastructure.Persistence.EntityConfiguration;
public class Events101Configuration : IEntityTypeConfiguration<Events101>
{
    public void Configure(EntityTypeBuilder<Events101> builder)
    {
        builder.ToTable("Events_101");
        builder.HasNoKey();
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.CustomerId).IsRequired();
        builder.Property(x => x.EventDate).IsRequired();
        builder.Property(x => x.EventTypeId).IsRequired();
    }
}
