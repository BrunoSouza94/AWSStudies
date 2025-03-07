﻿using Customers.Consumer.Contracts.Messages;
using MediatR;

namespace Customers.Consumer.Handlers;

public class CustomerCreatedHandler : IRequestHandler<CustomerCreated>
{
    private readonly ILogger<CustomerCreatedHandler> _logger;

    public CustomerCreatedHandler(ILogger<CustomerCreatedHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CustomerCreated request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Customer created: {request.FullName}");

        return Task.CompletedTask;
    }
}