namespace Application.DTOs;

public class UserRegisterDto
{ 
    public string Username { get; set; } = "";
    public string Email { get; set; }= "";
    public long PhoneNum { get; set; }
    public string Password { get; set; }= "";
}