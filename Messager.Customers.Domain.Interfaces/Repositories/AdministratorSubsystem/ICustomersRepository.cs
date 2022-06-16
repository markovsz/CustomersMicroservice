using Messager.Customers.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messager.Customers.Domain.Interfaces.Repositories
{
    namespace AdministratorSubsystem
    {
        public interface ICustomersRepository
        {
            Task<IEnumerable<Customer>> GetCustomers();
            Task<Customer> GetCustomerById(Guid id);
            Task<Customer> GetCustomerByTag(string tag);
            Task CreateCustomer(Customer customer);
            Task UpdateCustomer(Customer customer);
            Task DeleteCustomer(Customer customer);
        }
    }
}
