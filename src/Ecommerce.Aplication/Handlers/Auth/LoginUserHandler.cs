using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.Handlers;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, UserAuthResponseDto>
{
    private readonly IUserAuthService _userAuthService;
    private readonly IValidator<LoginUserCommand> _validator;

    public LoginUserHandler(IUserAuthService userAuthService, IValidator<LoginUserCommand> validator)
    {
        _userAuthService = userAuthService;
        _validator = validator;
    }

    public async Task<UserAuthResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        
         var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException($"Errores de validación: {errors}");
        }

        var loginDto = new UserLoginDto
        {
            Email = request.Email,
            Password = request.Password
        };

        return await _userAuthService.LoginAsync(loginDto);
    }
}