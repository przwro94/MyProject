using MyProject.Domain.Common;

namespace MyProject.Domain.Orders.Events;

public class OrderCreated : IDomainEvent
{
    public int OrderId { get; }
    public DateTime OccurredOn { get; }

    public OrderCreated(int orderId)
    {
        OrderId = orderId;
        OccurredOn = DateTime.UtcNow;
    }
}