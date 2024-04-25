using Customers.Api.Contracts.Data;
using Domain.Customer;

namespace Customers.Api.Mapping;

public static class DomainToDtoMapper
{
    public static CustomerDto ToCustomerDto(this Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            Email = customer.Email,
            GithubUserName = customer.GithubUserName,
            FullName = customer.FullName,
            DateOfBirth = customer.DateOfBirth
        };
    }
}
