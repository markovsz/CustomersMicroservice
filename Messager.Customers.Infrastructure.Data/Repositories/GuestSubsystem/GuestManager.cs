using Messager.Customers.Domain.Interfaces.Repositories.IGuestSubsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Infrastructure.Data.Repositories.GuestSubsystem
{
    public class GuestManager : IGuestManager
    {
        private ICustomersRepository _customersRepository;
        private RepositoryContext _context;

        public GuestManager(RepositoryContext context)
        {
            _context = context;
        }

        public ICustomersRepository Customers
        {
            get
            {
                if (_customersRepository is null)
                    _customersRepository = new CustomersRepository(_context);
                return _customersRepository;
            }
        }
        
        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();
    }
}
