using AutoMapper;
using Messager.Customers.Application.Services.DataTransferObjects;
using Messager.Customers.Application.Services.Services;
using Messager.Customers.Domain.Core.Models;
using Messager.Customers.Domain.Interfaces.Repositories.IGuestSubsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Infrastructure.Services.Services
{
    public class GuestService : IGuestService
    {
        private IMapper _mapper;
        private IGuestManager _guestManager;

        public GuestService(IGuestManager guestRepository, IMapper mapper)
        {
            _guestManager = guestRepository;
            _mapper = mapper;
        }

        public async Task CreateCustomerAsync(CustomerForCreateDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _guestManager.Customers.CreateCustomerAsync(customer);
        }
    }
}
