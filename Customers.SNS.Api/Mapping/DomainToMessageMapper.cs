using Customers.Api.Contracts.Messages;
using Domain.Customer;

namespace Customers.Api.Mapping;

public static class DomainToMessageMapper
{
    public static CustomerCreated ToCustomerCreatedMessage(this Customer customer)
    {
        return new CustomerCreated
        {
            Id = customer.Id,
            Email = customer.Email,
            GithubUserName = customer.GithubUserName,
            FullName = customer.FullName,
            DateOfBirth = customer.DateOfBirth
        };
    }

    public static CustomerUpdated ToCustomerUpdatedMessage(this Customer customer)
    {
        return new CustomerUpdated
        {
            Id = customer.Id,
            Email = customer.Email,
            GithubUserName = customer.GithubUserName,
            FullName = customer.FullName,
            DateOfBirth = customer.DateOfBirth
        };
    }
}