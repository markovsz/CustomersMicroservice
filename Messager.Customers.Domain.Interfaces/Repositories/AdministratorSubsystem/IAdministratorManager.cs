using System.Threading.Tasks;

namespace Messager.Customers.Domain.Interfaces.Repositories
{
    namespace AdministratorSubsystem
    {
        public interface IAdministratorManager
        {
            ICustomersRepositoryForAdministrator Customers { get; }
            Task SaveAsync();
        }
    }
}
