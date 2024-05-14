using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApplication.Infrastructure.Persistence.Entities;

namespace TestWebApplication.Infrastructure.Persistence.EntityConfiguration;
public class Events2Configuration : IEntityTypeConfiguration<Events2>
{
    public void Configure(EntityTypeBuilder<Events2> builder)
    {
        builder.ToTable("Events_2");
        builder.HasNoKey();
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.CustomerId).IsRequired();
        builder.Property(x => x.EventDate).IsRequired();
        builder.Property(x => x.EventTypeId).IsRequired();
    }
}
