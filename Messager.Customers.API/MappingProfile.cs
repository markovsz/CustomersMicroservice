using AutoMapper;
using Messager.Customers.Application.Services.DataTransferObjects;
using Messager.Customers.Domain.Core.Models;

namespace Messager.Customers.API
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
