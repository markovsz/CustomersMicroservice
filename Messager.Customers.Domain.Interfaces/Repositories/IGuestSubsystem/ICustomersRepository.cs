using Messager.Customers.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Domain.Interfaces.Repositories.IGuestSubsystem
{
    public interface ICustomersRepository
    {
        Task CreateCustomerAsync(Customer customer);
    }
}
