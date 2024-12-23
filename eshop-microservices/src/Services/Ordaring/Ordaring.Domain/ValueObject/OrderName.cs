namespace Ordaring.Domain.ValueObject;

public record OrderName
{
    private const int DefualtLength = 5;
    public string Value { get; }
    private OrderName(string value) => this.Value = value;

    public static OrderName Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefualtLength);
       
        return new OrderName(value);
    }
}