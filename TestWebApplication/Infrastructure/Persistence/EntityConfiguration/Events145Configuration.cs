using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApplication.Infrastructure.Persistence.Entities;

namespace TestWebApplication.Infrastructure.Persistence.EntityConfiguration;
public class Events145Configuration : IEntityTypeConfiguration<Events145>
{
    public void Configure(EntityTypeBuilder<Events145> builder)
    {
        builder.ToTable("Events_145");
        builder.HasNoKey();
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.CustomerId).IsRequired();
        builder.Property(x => x.EventDate).IsRequired();
        builder.Property(x => x.EventTypeId).IsRequired();
    }
}
