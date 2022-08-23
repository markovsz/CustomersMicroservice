using AutoMapper;
using Messager.Customers.Application.Services.DataTransferObjects;
using Messager.Customers.Application.Services.Services;
using Messager.Customers.Domain.Core.Models;
using Messager.Customers.Domain.Interfaces;
using Messager.Customers.Infrastructure.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messager.Customers.Infrastructure.Services.Services
{
    public class CustomersService : ICustomersService
    {
        private IRepositoryManager _customerManager;
        private IMapper _mapper;

        public CustomersService(IRepositoryManager customerManager, IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;
        }

        private async Task<bool> CheckCustomerForExistenceByUserIdAsync(Guid userId)
        {
            var customer = await _customerManager.Customers.GetCustomerByUserIdAsync(userId, false);
            return customer is not null;
        }

        public async Task<CustomerForReadPublicInfoDto> CreateCustomerAsync(Guid userId, CustomerForCreateDto customerDto)
        {
            if (await CheckCustomerForExistenceByUserIdAsync(userId))
                throw new EntityIsAlreadyExistingException<Customer>();
            var customer = _mapper.Map<Customer>(customerDto);
            customer.UserId = userId;
            await _customerManager.Customers.CreateCustomerAsync(customer);
            await _customerManager.SaveAsync();
            var customerCreatedDto = _mapper.Map<CustomerForReadPublicInfoDto>(customer);
            return customerCreatedDto;
        }

        public async Task DeleteCustomerByUserIdAsync(Guid userId)
        {
            var customer = await _customerManager.Customers.GetCustomerByUserIdAsync(userId, false);
            if (customer is null)
                throw new EntityDoesntExistException<Customer>();
            _customerManager.Customers.DeleteCustomer(customer);
            await _customerManager.SaveAsync();
        }

        public async Task<CustomerForReadPrivateInfoDto> GetCustomerInfoByUserIdAsync(Guid userId, bool trackChanges)
        {
            var customer = await _customerManager.Customers.GetCustomerByUserIdAsync(userId, trackChanges);
            if (customer is null)
                throw new EntityDoesntExistException<Customer>();
            var customerDto = _mapper.Map<CustomerForReadPrivateInfoDto>(customer);
            return customerDto;
        }
        public async Task<CustomerForReadMinimizedDto> GetMinimizedCustomerInfoByUserIdAsync(Guid userId, bool trackChanges)
        {
            var customer = await _customerManager.Customers.GetCustomerByUserIdAsync(userId, trackChanges);
            if (customer is null)
                throw new EntityDoesntExistException<Customer>();
            var customerDto = _mapper.Map<CustomerForReadMinimizedDto>(customer);
            return customerDto;
        }

        public async Task<IEnumerable<CustomerForReadMinimizedDto>> GetMinimizedCustomersInfoByUserIdsAsync(IEnumerable<Guid> userIds)
        {
            var customers = new List<Customer>();
            foreach(var userId in userIds)
            {
                var customer = await _customerManager.Customers.GetCustomerByUserIdAsync(userId, false);
                if(customer is not null)
                    customers.Add(customer);
            }

            var customersDto = _mapper.Map<IEnumerable<CustomerForReadMinimizedDto>>(customers);
            return customersDto;
        }

        public async Task<CustomerForReadPublicInfoDto> GetCustomerByTagAsync(string tag, bool trackChanges)
        {
            var customer = await _customerManager.Customers.GetCustomerByTagAsync(tag, trackChanges);
            if (customer is null)
                throw new EntityDoesntExistException<Customer>();
            var customerDto = _mapper.Map<CustomerForReadPublicInfoDto>(customer);
            return customerDto;
        }

        public async Task<IEnumerable<CustomerForReadPublicInfoDto>> GetCustomersAsync()
        {
            var customers = await _customerManager.Customers.GetCustomersAsync();
            var customersDto = _mapper.Map<IEnumerable<CustomerForReadPublicInfoDto>>(customers);
            return customersDto;
        }

        public async Task UpdateCustomerAsync(Guid userId, CustomerForUpdateDto customerDto)
        {
            if (!(await CheckCustomerForExistenceByUserIdAsync(userId)))
                throw new EntityDoesntExistException<Customer>();
            var customer = _mapper.Map<Customer>(customerDto);
            customer.UserId = userId;
            _customerManager.Customers.UpdateCustomer(customer);
            await _customerManager.SaveAsync();
        }
    }
}
