namespace Application.DTOs;

public class UserAuthResponseDto
{
    public string Username { get; set; } = "";
    public string Email{ get; set; }
    public string Token { get; set; } = "";
}