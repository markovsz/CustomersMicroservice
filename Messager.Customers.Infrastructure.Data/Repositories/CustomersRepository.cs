using Messager.Customers.Domain.Core.Models;
using Messager.Customers.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messager.Customers.Infrastructure.Data.Repositories
{
    public class CustomersRepository : RepositoryBase<Customer>, ICustomersRepository
    {
        public CustomersRepository(RepositoryContext context)
            : base(context)
        {
        }

        public async Task CreateCustomerAsync(Customer customer) =>
            await CreateAsync(customer);

        public void DeleteCustomer(Customer customer) =>
            Delete(customer);

        public async Task<Customer> GetCustomerByUserIdAsync(Guid userId, bool trackChanges) =>
            await FindByCondition(c => c.UserId.Equals(userId), false)
            .FirstOrDefaultAsync();

        public async Task<Customer> GetCustomerByTagAsync(string tag, bool trackChanges) =>
            await FindByCondition(c => c.CustomerTag.Equals(tag), false)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Customer>> GetCustomersAsync() =>
            await FindAll(false)
            .ToListAsync();

        public IQueryable<Customer> GetCustomersInfoByUserIdsAsync1() =>
            FindAll(false);

        public void UpdateCustomer(Customer customer) =>
            Update(customer);

    }
}
