namespace BusinessObjects.Exceptions;

public class ArgumentOutOfRangeException : Exception
{
    public ArgumentOutOfRangeException(string message) : base(message)
    {
    }

    public ArgumentOutOfRangeException(string message, Exception innerException) : base(message, innerException)
    {
    }
}