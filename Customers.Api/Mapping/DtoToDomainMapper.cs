using Customers.Api.Contracts.Data;
using Domain.Customer;

namespace Customers.Api.Mapping;

public static class DtoToDomainMapper
{
    public static Customer ToCustomer(this CustomerDto customerDto)
    {
        return new Customer
        {
            Id = customerDto.Id,
            Email = customerDto.Email,
            GithubUserName = customerDto.GithubUserName,
            FullName = customerDto.FullName,
            DateOfBirth = customerDto.DateOfBirth
        };
    }
}
