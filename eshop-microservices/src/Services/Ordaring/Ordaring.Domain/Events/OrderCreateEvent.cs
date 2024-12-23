namespace Ordaring.Domain.Events;

public record OrderCreateEvent(Order Order) : IDomainEvent;