using AppService.Interfaces.Users;
using Contract.Users;
using Contract.Users.Commands;

namespace AppService.Services.Users;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<UserModel> Execute(LoginRequest loginRequest) => await userRepository.Execute(loginRequest);
}
