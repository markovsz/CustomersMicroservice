using Messager.Customers.Domain.Interfaces;
using Messager.Customers.Domain.Interfaces.Repositories;
using Messager.Customers.Infrastructure.Data.Repositories;
using System.Threading.Tasks;

namespace Messager.Customers.Infrastructure.Data
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _context;
        private ICustomersRepository _customersRepository;
        private IIconsRepository _iconsRepository;

        public RepositoryManager(RepositoryContext context)
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

        public IIconsRepository Icons
        {
            get
            {
                if (_iconsRepository is null)
                    _iconsRepository = new IconsRepository(_context);
                return _iconsRepository;
            }
        }

        public async Task SaveAsync() => 
            await _context.SaveChangesAsync();
    }
}
