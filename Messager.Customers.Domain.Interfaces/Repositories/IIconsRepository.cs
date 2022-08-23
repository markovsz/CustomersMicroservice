using Messager.Customers.Domain.Core.Models;
using System;
using System.Threading.Tasks;

namespace Messager.Customers.Domain.Interfaces.Repositories
{
    public interface IIconsRepository
    {
        Task CreateIconAsync(Icon icon);
        Task<Icon> GetIconAsync(Guid iconId);
    }
}
