using Contract.Users;
using Contract.Users.Commands;
using Domain.Users.Entities;
using Infra.AppDbContexes;
using Microsoft.EntityFrameworkCore;

namespace Infra.Users;

public class UserRepository(AppDbContext db) : IUserRepository
{
    public async Task<UserModel> Execute(LoginRequest loginRequest)
    {
        var user = await db.Users.Where(x => x.Email == loginRequest.Email && x.Password == loginRequest.Password).FirstOrDefaultAsync();

        if (user == null)
            return null;

        return new UserModel { Id = user.Id, FullName = user.FullName, Email = user.Email, Role = user.Role};
    }

    public async Task<User> Execute(CreateUserCommand command)
    {
        var user = User.Create(Guid.NewGuid(), command.FullName, command.Email, command.Password, command.Role);
        await db.Users.AddAsync(user);
        db.SaveChanges();
        return user;
    }
}
