﻿namespace Domain.Customer;

public sealed class Customer
{
    public required Guid Id { get; init; } = Guid.NewGuid();

    public required string FullName { get; init; }

    public required string Email { get; init; }

    public required string GithubUserName { get; init; }

    public required DateTime DateOfBirth { get; init; }
}