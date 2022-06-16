using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messager.Customers.Domain.Core.Models;
using Messager.Customers.Domain.Interfaces.Repositories.AdministratorSubsystem;
using Microsoft.EntityFrameworkCore;

namespace Messager.Customers.Infrastructure.Data.Repositories.AdministratorSubsystem
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

        public Task<Customer> GetCustomerByIdAsync(Guid id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(id), false)
            .FirstOrDefaultAsync();

        public Task<Customer> GetCustomerByTagAsync(string tag, bool trackChanges) =>
            FindByCondition(c => c.CustomerTag.Equals(tag), false)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Customer>> GetCustomersAsync() =>
            await FindAll(false)
            .ToListAsync();

        public void UpdateCustomer(Customer customer) =>
            Update(customer);
    }
}
