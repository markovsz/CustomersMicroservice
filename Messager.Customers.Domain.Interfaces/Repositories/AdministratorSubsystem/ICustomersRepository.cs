using Messager.Customers.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Domain.Interfaces.Repositories.AdministratorSubsystem
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(Guid id);
        Customer GetCustomerByName(string userName);

    }
}
