using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Infrastructure.Persistence.Entities;

public class Tenant
{
    [Key]
    public int Id { get; set; }

    [MaxLength(128)]
    public string OrganisationName { get; set; } = null!;
}


