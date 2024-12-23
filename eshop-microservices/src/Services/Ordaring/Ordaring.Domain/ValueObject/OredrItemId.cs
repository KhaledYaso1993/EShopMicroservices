namespace Ordaring.Domain.ValueObject;

public record OrderItemId
{
    public Guid Value { get; }
    private OrderItemId(Guid value)=>  this.Value = value;
    public static OrderItemId Of(Guid value) {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty) {

            throw new DomainException("OrderItemId Cannot be null");
        }
        return new OrderItemId(value);
    }
}
