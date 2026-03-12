namespace BusinessObjects.Exceptions;

public class AuthenticationException : Exception
{
    public AuthenticationException() : base() { }
    public AuthenticationException(string message) : base(message) { }
    public AuthenticationException(string message, Exception exp) : base(message, exp) { }
}

