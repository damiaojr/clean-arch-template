namespace OI.Template.Domain.Exceptions;

public class UnsupportedColourException : Exception
{
    public UnsupportedColourException(string code) : base($"Colour \"{code}\" not supported.")
    {
    }
}