namespace TestWebApplication.Infrastructure.Persistence.Entities;

public class Customer2
{
    public int Id { get; set; }
    public string GivenName { get; set; } = null!;
    public string FamilyName { get; set; } = null!;
    public string JobPosition { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
}
