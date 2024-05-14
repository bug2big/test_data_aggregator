namespace TestWebApplication.Infrastructure.Persistence.Entities;

public class Customer101
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = null!;
    public bool IsActive { get; set; }
    public string Salutation { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateTime LastLoginDate { get; set; }
}
