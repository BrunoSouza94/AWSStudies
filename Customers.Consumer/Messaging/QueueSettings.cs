namespace Customers.Consumer.Messaging;

public sealed class QueueSettings
{
    public const string Key = "Queue";
    public required string Name { get; set; }
}