using Messager.Customers.Domain.Core.Models;
using Messager.Customers.Domain.Interfaces.Repositories.IGuestSubsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Infrastructure.Data.Repositories.GuestSubsystem
{
    public class CustomersRepositoryForGuest : RepositoryBase<Customer>, ICustomersRepositoryForGuest
    {
        public CustomersRepositoryForGuest(RepositoryContext context)
            : base(context)
        {
        }

        public async Task CreateCustomerAsync(Customer customer) =>
            await CreateAsync(customer);
    }
}
