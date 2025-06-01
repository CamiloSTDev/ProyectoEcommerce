using Application.DTOs;
using MediatR;

namespace Application.Commands;

public class LoginUserCommand : IRequest<UserAuthResponseDto>
{

    public string Email { get; set; } = "";
    public string Password { get; set; } = "";


}
