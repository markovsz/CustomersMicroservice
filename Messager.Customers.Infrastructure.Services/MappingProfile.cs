using AutoMapper;
using Messager.Customers.Application.Services.DataTransferObjects;
using Messager.Customers.Domain.Core.Models;

namespace Messager.Customers.Infrastructure.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerForCreateDto, Customer>();
            CreateMap<Customer, CustomerForReadPublicInfoDto>();
            CreateMap<Customer, CustomerForReadPrivateInfoDto>();
            CreateMap<Customer, CustomerForReadMinimizedDto>();
            CreateMap<CustomerForUpdateDto, Customer>();
        }
    }
}
