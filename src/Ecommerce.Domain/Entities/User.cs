using System.Numerics;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = "";
    public string Email { get; set; }= "";
    public long PhoneNum { get; set; }
    public string Password { get; set; }= "";
    public string Rol { get; set; }= "Cliente";
}