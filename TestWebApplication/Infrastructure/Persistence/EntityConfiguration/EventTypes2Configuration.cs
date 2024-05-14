using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApplication.Infrastructure.Persistence.Entities;

namespace TestWebApplication.Infrastructure.Persistence.EntityConfiguration;
public class EventTypes2Configuration : IEntityTypeConfiguration<EventTypes2>
{
    public void Configure(EntityTypeBuilder<EventTypes2> builder)
    {
        builder.ToTable("EventTypes_2");
        builder.HasNoKey();
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
    }
}
