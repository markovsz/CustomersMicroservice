using Messager.Customers.Application.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Application.Services.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerForReadDto>> GetCustomersAsync();
        Task<CustomerForReadDto> GetCustomerByIdAsync(Guid id, bool trackChanges);
        Task<CustomerForReadDto> GetCustomerByTagAsync(string tag, bool trackChanges);
    }
}
