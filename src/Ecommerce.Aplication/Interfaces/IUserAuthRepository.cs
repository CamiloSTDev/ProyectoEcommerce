using Domain.Entities;

namespace Application.Interfaces;

public interface IUserAuthRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<bool> IsEmailTakenAsync(string email);
    Task<User> RegisterUserAsync(User user);
}