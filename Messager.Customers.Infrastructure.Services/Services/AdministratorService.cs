using AutoMapper;
using Messager.Customers.Application.Services.DataTransferObjects;
using Messager.Customers.Application.Services.Services;
using Messager.Customers.Domain.Core.Models;
using Messager.Customers.Domain.Interfaces.Repositories.AdministratorSubsystem;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<CustomerForReadDto> GetCustomerByIdAsync(Guid id, bool trackChanges)
        {
            var customer = await _administratorManager.Customers.GetCustomerByIdAsync(id, trackChanges);
            var customerDto = _mapper.Map<CustomerForReadDto>(customer);
            return customerDto;
        }

        public async Task<CustomerForReadDto> GetCustomerByTagAsync(string tag, bool trackChanges)
        {
            var customer = await _administratorManager.Customers.GetCustomerByTagAsync(tag, trackChanges);
            var customerDto = _mapper.Map<CustomerForReadDto>(customer);
            return customerDto;
        }

        public async Task<IEnumerable<CustomerForReadDto>> GetCustomersAsync()
        {
            var customer = await _administratorManager.Customers.GetCustomersAsync();
            var customerDto = _mapper.Map<IEnumerable<CustomerForReadDto>>(customer);
            return customerDto;
        }
    }
}
