namespace Customers.Consumer.Contracts.Messages;

public class CustomerDeleted : ISQSMessage
{
    public required Guid Id { get; init; }
}