using OI.Template.Domain.Exceptions;

namespace OI.Template.Domain.ValueObjects;

public class Colour : ValueObject
{
    static Colour() {}
    private Colour() {}

    private Colour(string code)
    {
        Code = code;
    }

    public static Colour From(string code)
    {
        var colour = new Colour { Code = code };
        if (!SupportedColourCollection.Contains(colour))
        {
            throw new UnsupportedColourException(code);
        }

        return colour;
    }

    public static Colour White => new("#FFFFFF");
    public static Colour Red => new("#FF5733");

    public string Code { get; private set; } = "#000000";

    public static implicit operator string(Colour colour)
    {
        return colour.ToString();
    }

    public static implicit operator Colour(string code)
    {
        return From(code);
    }

    protected static IEnumerable<Colour> SupportedColourCollection
    {
        get
        {
            yield return White;
            yield return Red;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}