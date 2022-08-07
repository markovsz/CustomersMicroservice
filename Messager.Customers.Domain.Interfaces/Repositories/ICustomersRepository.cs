using Messager.Customers.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messager.Customers.Domain.Interfaces.Repositories
{
    public interface ICustomersRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByUserIdAsync(Guid id, bool trackChanges);
        Task<Customer> GetCustomerByTagAsync(string tag, bool trackChanges);
        Task CreateCustomerAsync(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
