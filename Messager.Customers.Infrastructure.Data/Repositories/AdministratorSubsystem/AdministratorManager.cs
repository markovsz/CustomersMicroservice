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
        private ICustomersRepositoryForAdministrator _customersRepository;

        public AdministratorManager(RepositoryContext context)
        {
            _context = context;
        }

        public ICustomersRepositoryForAdministrator Customers
        {
            get
            {
                if (_customersRepository is null)
                    _customersRepository = new CustomersRepositoryForAdministrator(_context);
                return _customersRepository;
            }
        }

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();
    }
}
