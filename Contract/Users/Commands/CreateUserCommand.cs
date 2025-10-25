using Domain.Users.Enums;

namespace Contract.Users.Commands;

public class CreateUserCommand
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleType Role { get; set; }
}
