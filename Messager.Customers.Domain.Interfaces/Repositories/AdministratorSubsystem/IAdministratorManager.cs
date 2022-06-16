using System.Threading.Tasks;

namespace Messager.Customers.Domain.Interfaces.Repositories
{
    namespace AdministratorSubsystem
    {
        public interface IAdministratorManager
        {
            ICustomersRepository Customers { get; }
            Task SaveAsync();
        }
    }
}
