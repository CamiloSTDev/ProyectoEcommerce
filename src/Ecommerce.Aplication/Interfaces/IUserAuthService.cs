using Domain.Entities;

namespace Application.Interfaces;

public interface IUserAuthService
{
    Task<User> RegisterAsync(User user);
    Task<User?> LoginAsync(string username, string password);
}