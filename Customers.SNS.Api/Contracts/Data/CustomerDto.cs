﻿namespace Customers.Api.Contracts.Data;

public class CustomerDto
{
    public Guid Id { get; init; } = default!;

    public string GithubUserName { get; init; } = default!;

    public string FullName { get; init; } = default!;

    public string Email { get; init; } = default!;

    public DateTime DateOfBirth { get; init; }
}
