using Contract.Users;
using Contract.Users.Commands;

namespace AppService.Interfaces.Users;

public interface IUserService
{
    Task<UserModel> Execute(LoginRequest loginRequest);
}
