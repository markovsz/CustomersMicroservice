using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messager.Customers.Domain.Interfaces.Repositories.AdministratorSubsystem;

namespace Messager.Customers.Infrastructure.Data.Repositories.AdministratorSubsystem
{
    public class AdministratorManager : IAdministratorManager
    {
        private RepositoryContext _context;
        private ICustomersRepository _customersRepository;

        public AdministratorManager(RepositoryContext context)
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
