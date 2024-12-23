
namespace Ordaring.Domain.Events;

public record OrderUpdateEvent(Order Order) :IDomainEvent;

