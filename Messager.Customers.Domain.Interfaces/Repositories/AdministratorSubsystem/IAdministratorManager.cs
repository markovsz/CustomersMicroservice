using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Domain.Interfaces.Repositories.AdministratorSubsystem
{
    public interface IAdministratorManager
    {
        ICustomersRepository Customers { get; }
        Task SaveAsync();
    }
}
