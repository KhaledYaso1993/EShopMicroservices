using MediatR;

namespace Ordering.Domain.Abstractions;

public  interface IDomainEvent:INotification
{
     Guid EventId=>Guid.NewGuid();
    public DateTime Occouredon=>DateTime.Now;
    public string EventName => GetType().AssemblyQualifiedName;
}
