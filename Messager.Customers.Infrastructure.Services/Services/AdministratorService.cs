using AutoMapper;
using Messager.Customers.Application.Services.DataTransferObjects;
using Messager.Customers.Application.Services.Services;
using Messager.Customers.Domain.Core.Models;
using Messager.Customers.Domain.Interfaces.Repositories.AdministratorSubsystem;
using System;
using System.Collections.Generic;

namespace Messager.Customers.Infrastructure.Services.Services
{
    public class AdministratorService : IAdministratorService
    {
        private IAdministratorManager _administratorManager;
        private IMapper _mapper;

        public AdministratorService(IAdministratorManager administratorManager, IMapper mapper)
        {
            _administratorManager = administratorManager;
        }

        public void CreateCustomer(CustomerForCreateDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _administratorManager.Customers.CreateCustomer(customer);
        }

        public CustomerForReadDto GetCustomerById(Guid id)
        {
            var customer = _administratorManager.Customers.GetCustomerById(id);
            var customerDto = _mapper.Map<CustomerForReadDto>(customer);
            return customerDto;
        }

        public CustomerForReadDto GetCustomerByTag(string userName)
        {
            var customer = _administratorManager.Customers.GetCustomerByTag(userName);
            var customerDto = _mapper.Map<CustomerForReadDto>(customer);
            return customerDto;
        }

        public IEnumerable<CustomerForReadDto> GetCustomers()
        {
            var customer = _administratorManager.Customers.GetCustomers();
            var customerDto = _mapper.Map<IEnumerable<CustomerForReadDto>>(customer);
            return customerDto;
        }
    }
}
