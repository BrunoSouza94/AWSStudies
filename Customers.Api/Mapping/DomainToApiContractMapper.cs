﻿using Customers.Api.Contracts.Responses;
using Domain.Customer;

namespace Customers.Api.Mapping;

public static class DomainToApiContractMapper
{
    public static CustomerResponse ToCustomerResponse(this Customer customer)
    {
        return new CustomerResponse
        {
            Id = customer.Id,
            Email = customer.Email,
            GithubUserName = customer.GithubUserName,
            FullName = customer.FullName,
            DateOfBirth = customer.DateOfBirth
        };
    }

    public static GetAllCustomersResponse ToCustomersResponse(this IEnumerable<Customer> customers)
    {
        return new GetAllCustomersResponse
        {
            Customers = customers.Select(x => new CustomerResponse
            {
                Id = x.Id,
                Email = x.Email,
                GithubUserName = x.GithubUserName,
                FullName = x.FullName,
                DateOfBirth = x.DateOfBirth
            })
        };
    }
}
