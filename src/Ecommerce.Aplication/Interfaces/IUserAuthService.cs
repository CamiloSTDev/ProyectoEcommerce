using Application.DTOs;

namespace Application.Interfaces;

public interface IUserAuthService
{
    Task<UserAuthResponseDto> RegisterAsync(UserRegisterDto registerDto);
    Task<UserAuthResponseDto> LoginAsync(UserLoginDto loginDto);
}