namespace Customers.Consumer.Contracts.Messages;

public class CustomerCreated : ISQSMessage
{
    public required Guid Id { get; init; }

    public required string FullName { get; init; }

    public required string Email { get; init; }

    public required string GithubUserName { get; init; }

    public required DateTime DateOfBirth { get; init; }
}