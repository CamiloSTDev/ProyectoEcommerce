
namespace Application.Exceptions;

public class AuthException : Exception
{
    public AuthException(string message) : base(message) { }
    public AuthException(string message, Exception innerException) : base(message, innerException) { }
}

public class UserAlreadyExistsException : AuthException
{
    public UserAlreadyExistsException(string email)
        : base($"Usuario con email {email} ya existe") { }
}

public class InvalidCredentialsException : AuthException
{
    public InvalidCredentialsException()
        : base("Credenciales inválidas") { }
}