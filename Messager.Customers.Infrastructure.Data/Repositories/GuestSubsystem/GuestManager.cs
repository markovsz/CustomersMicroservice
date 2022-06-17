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
        private ICustomersRepositoryForGuest _customersRepository;
        private RepositoryContext _context;

        public GuestManager(RepositoryContext context)
        {
            _context = context;
        }

        public ICustomersRepositoryForGuest Customers
        {
            get
            {
                if (_customersRepository is null)
                    _customersRepository = new CustomersRepositoryForGuest(_context);
                return _customersRepository;
            }
        }
        
        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();
    }
}
