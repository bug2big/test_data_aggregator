namespace TestWebApplication.Infrastructure.Persistence.Entities;

public class Events2
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string EventTypeId { get; set; } = null!;

    public DateTime EventDate { get; set; }

}
