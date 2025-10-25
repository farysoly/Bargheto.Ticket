using Contract.Users.Commands;
using Domain.Users.Entities;

namespace Contract.Users;

public interface IUserRepository
{
    Task<UserModel> Execute(LoginRequest loginRequest);
    Task<User> Execute(CreateUserCommand command);
}
