using AutoMapper;
using Messager.Customers.Application.Services.DataTransferObjects;
using Messager.Customers.Domain.Core.Models;

namespace Messager.Customers.Infrastructure.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerForReadDto>();
            CreateMap<CustomerForCreateDto, Customer>();
        }
    }
}
