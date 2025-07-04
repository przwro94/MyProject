using MyProject.Domain.Common;

namespace MyProject.Domain.Orders.Events;

public class OrderItemAdded : IDomainEvent
{
    public int OrderId { get; }
    public int OrderItemId { get; }
    public DateTime OccurredOn { get; }

    public OrderItemAdded(int orderId, int orderItemId)
    {
        OrderId = orderId;
        OrderItemId = orderItemId;
        OccurredOn = DateTime.UtcNow;
    }
}