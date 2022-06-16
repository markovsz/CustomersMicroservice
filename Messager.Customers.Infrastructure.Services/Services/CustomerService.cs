using Messager.Customers.Application.Services.Services;
using Messager.Customers.Domain.Interfaces.Repositories.CustomerSubsystem;

namespace Messager.Customers.Infrastructure.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerManager _customerManager;

        public CustomerService(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
    }
}
