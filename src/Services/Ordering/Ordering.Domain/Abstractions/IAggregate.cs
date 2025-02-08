namespace Ordering.Domain.Abstractions;


public interface IAggregate<T>: IAggregate,Entity<T>
{
}
public  interface IAggregate
{
    IReadOnlyList<IDomainEvent> DomainEvent {  get; }
    IDomainEvent[] ClearDomainEvent();
}
