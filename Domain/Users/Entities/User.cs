using Domain.Tickets.Entities;
using Domain.Users.Enums;

namespace Domain.Users.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public RoleType Role { get; private set; }

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
