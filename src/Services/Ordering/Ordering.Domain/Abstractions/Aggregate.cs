namespace Ordering.Domain.Abstractions;

public class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    private readonly List<IDomainEvent>_domainEvents=new();
    public IReadOnlyList<IDomainEvent> DomainEvent => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent) {
         _domainEvents.Add(domainEvent);
    }
    public IDomainEvent[] ClearDomainEvent()
    {
        IDomainEvent[] dequeuedEntites=_domainEvents.ToArray();

        _domainEvents.Clear();

        return dequeuedEntites;

    }
}
