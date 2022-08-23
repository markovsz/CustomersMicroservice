using Messager.Customers.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Messager.Customers.Domain.Interfaces
{
    public interface IRepositoryManager
    {
        ICustomersRepository Customers { get; }
        IIconsRepository Icons { get; }
        Task SaveAsync();
    }
}
