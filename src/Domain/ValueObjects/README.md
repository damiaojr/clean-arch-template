# Value Objects

A value object represents a single value or concept, such as a number, string, date, or monetary amount. Unlike other objects in a software system, a value object is defined by its value rather than its identity, meaning that two value objects are considered equal if they have the same value, regardless of their memory location or other properties.

Value objects are often used to encapsulate a particular concept or behavior within a software system. They can help to simplify code and reduce complexity by providing a clear and consistent interface for working with a specific type of data.

```c#
public struct EmailAddress
{
    private readonly string _value;

    public EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email address must not be empty.", nameof(value));

        _value = value;
    }

    public override string ToString() => _value;
}
```

