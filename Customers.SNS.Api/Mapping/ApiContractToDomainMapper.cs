using Customers.Api.Contracts.Requests;
using Domain.Customer;

namespace Customers.Api.Mapping;

public static class ApiContractToDomainMapper
{
    public static Customer ToCustomer(this CustomerRequest request)
    {
        return new Customer
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            GithubUserName = request.GithubUserName,
            FullName = request.FullName,
            DateOfBirth = request.DateOfBirth
        };
    }

    public static Customer ToCustomer(this UpdateCustomerRequest request)
    {
        return new Customer
        {
            Id = request.Id,
            Email = request.Customer.Email,
            GithubUserName = request.Customer.GithubUserName,
            FullName = request.Customer.FullName,
            DateOfBirth = request.Customer.DateOfBirth
        };
    }
}
