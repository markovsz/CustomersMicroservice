using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messager.Customers.Domain.Interfaces.Repositories.CustomerSubsystem;

namespace Messager.Customers.Infrastructure.Data.Repositories.CustomerSubsystem
{
    public class CustomerManager : ICustomerManager
    {
        private RepositoryContext _context;
        private ICustomersRepositoryForCustomer _customersRepository;

        public CustomerManager(RepositoryContext context)
        {
            _context = context;
        }

        public ICustomersRepositoryForCustomer Customers
        {
            get
            {
                if (_customersRepository is null)
                    _customersRepository = new CustomersRepositoryForCustomer(_context);
                return _customersRepository;
            }
        }

        public async Task SaveAsync() => 
            await _context.SaveChangesAsync();
    }
}
