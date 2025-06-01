using Domain.Entities;

namespace Application.Interfaces;
public interface ITokenService
{
    string GenerateToken(User user);
}