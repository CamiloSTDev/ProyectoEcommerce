using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserAuthRepository
{
    Task<User?> GetUserByEmailAsync(string email, string password); //login
    Task<bool> IsEmailTakenAsync(string email);
    Task<User> RegisterUserAsync(User user);
}