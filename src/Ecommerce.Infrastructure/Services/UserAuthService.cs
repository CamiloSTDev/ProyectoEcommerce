using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Services;

public class UserAuthService : IUserAuthService
{
    private readonly IUserAuthRepository _userAuthRepository;
    private readonly IEncryptionService _encryptionService;
    private readonly ITokenService _tokenService;

    public UserAuthService(IUserAuthRepository userAuthRepository, IEncryptionService encryptionService, ITokenService tokenService)
    {
        _userAuthRepository = userAuthRepository;
        _encryptionService = encryptionService;
        _tokenService = tokenService;
    }

    public async Task<UserAuthResponseDto> RegisterAsync(UserRegisterDto registerDto)
    {
        if (await _userAuthRepository.IsEmailTakenAsync(registerDto.Email))
        {
            throw new UserAlreadyExistsException(registerDto.Email);
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = registerDto.Username,
            Email = registerDto.Email.ToLowerInvariant(),
            PhoneNum = registerDto.PhoneNum,
            Password = _encryptionService.HashPassword(registerDto.Password),
            Role = "Cliente",
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        var createdUser = await _userAuthRepository.RegisterUserAsync(user);

        var token = _tokenService.GenerateToken(createdUser);

        return new UserAuthResponseDto
        {
            Id = createdUser.Id.ToString(),
            Username = createdUser.Username,
            Email = createdUser.Email,
            Token = token
        };
    }

    public async Task<UserAuthResponseDto> LoginAsync(UserLoginDto loginDto)
    {
        var user = await _userAuthRepository.GetUserByEmailAsync(loginDto.Email);

        if (user == null || !user.IsActive)
        {
            throw new InvalidCredentialsException();
        }

        if (!_encryptionService.VerifyPassword(loginDto.Password, user.Password))
        {
            throw new InvalidCredentialsException();
        }

        var token = _tokenService.GenerateToken(user);

        return new UserAuthResponseDto
        {
            Id = user.Id.ToString(),
            Username = user.Username,
            Email = user.Email,
            Token = token
        };
    }

}	