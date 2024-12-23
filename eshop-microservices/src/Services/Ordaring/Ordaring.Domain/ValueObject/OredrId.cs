namespace Ordaring.Domain.ValueObject;

public record OrderId
{
    public Guid Value { get; }
    private OrderId(Guid value) => this.Value = value;

    public static OrderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("OrderId Cannot be null");
        }

        return new OrderId(value);
    }

}
