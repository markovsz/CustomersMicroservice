using System.Threading.Tasks;

namespace Messager.Customers.Domain.Interfaces.Repositories
{
    namespace CustomerSubsystem
    {
        public interface ICustomerManager
        {
            ICustomersRepository Customers { get; }
            Task SaveAsync();
        }
    }
}
