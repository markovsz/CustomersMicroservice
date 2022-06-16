using Messager.Customers.Application.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Application.Services.Services
{
    public interface IAdministratorService
    {
        IEnumerable<CustomerForReadDto> GetCustomers();
        CustomerForReadDto GetCustomerById(Guid id);
        CustomerForReadDto GetCustomerByTag(string tag);
        void CreateCustomer(CustomerForCreateDto customerDto);
    }
}
