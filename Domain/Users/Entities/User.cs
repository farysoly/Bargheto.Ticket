using Domain.Tickets.Entities;
using Domain.Users.Enums;

namespace Domain.Users.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleType Role { get; set; }

    public ICollection<Ticket> CreatedTickets { get; set; } = [];

    public User()
    {
    }

    public User(Guid id, string fullName, string email, string password, RoleType roleType)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        Password = password;
        Role = roleType;
    }

    public static User Create(Guid id, string fullName, string email, string password, RoleType roleType)
        => new User(id, fullName, email, password, roleType);
}
