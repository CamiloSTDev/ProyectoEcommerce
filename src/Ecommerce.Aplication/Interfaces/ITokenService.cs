namespace Application.Interfaces;
public interface ITokenService
{
    string GenerateToken(string userId, string username, string email, string role);
}