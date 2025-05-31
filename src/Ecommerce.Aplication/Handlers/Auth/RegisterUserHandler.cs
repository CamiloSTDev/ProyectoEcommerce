using Application.DTOs;
using Application.Interfaces;

namespace Application.Handlers
{
    public class RegisterUserHandler
    {
        private readonly IUserAuthService _userAuthService;

        public RegisterUserHandler(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        public async Task<UserAuthResponseDto> HandleAsync(UserRegisterDto dto)
        {
            return await _userAuthService.RegisterAsync(dto);
        }
    }
}
