namespace MyProject.Domain.Common;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}