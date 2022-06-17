using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messager.Customers.Domain.Core.Models;
using Messager.Customers.Domain.Interfaces.Repositories.CustomerSubsystem;
using Microsoft.EntityFrameworkCore;

namespace Messager.Customers.Infrastructure.Data.Repositories.CustomerSubsystem
{
    public class CustomersRepositoryForCustomer : RepositoryBase<Customer>, ICustomersRepositoryForCustomer
    {
        public CustomersRepositoryForCustomer(RepositoryContext context)
            : base(context)
        {
        }

        public async Task CreateCustomerAsync(Customer customer) =>
            await CreateAsync(customer);

        public void DeleteCustomer(Customer customer) =>
            Delete(customer);

        public async Task<Customer> GetCustomerByIdAsync(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), false)
            .FirstOrDefaultAsync();

        public async Task<Customer> GetCustomerByTagAsync(string tag, bool trackChanges) =>
            await FindByCondition(c => c.CustomerTag.Equals(tag), false)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Customer>> GetCustomersAsync() =>
            await FindAll(false)
            .ToListAsync();

        public void UpdateCustomer(Customer customer) =>
            Update(customer);

    }
}
