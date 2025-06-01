using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserAuthResponseDto>
    {
        private readonly IUserAuthService _userAuthService;
        private readonly IValidator<RegisterUserCommand> _validator;

        public RegisterUserHandler(IUserAuthService userAuthService, IValidator<RegisterUserCommand> validator)
        {
            _userAuthService = userAuthService;
            _validator = validator;
        }

        public async Task<UserAuthResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException($"Errores de validación: {errors}");
            }

            var registerDto = new UserRegisterDto
            {
                Username = request.Username,
                Email = request.Email,
                PhoneNum = request.PhoneNum,
                Password = request.Password,
                Role = request.Role
            };

            return await _userAuthService.RegisterAsync(registerDto);
        }
    }
}
