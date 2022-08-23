using Messager.Customers.Application.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messager.Customers.Application.Services.Services
{
    public interface ICustomersService
    {
        Task<CustomerForReadPublicInfoDto> CreateCustomerAsync(Guid userId, CustomerForCreateDto customerDto);
        Task<IEnumerable<CustomerForReadPublicInfoDto>> GetCustomersAsync();
        Task<IEnumerable<CustomerForReadMinimizedDto>> GetMinimizedCustomersInfoByUserIdsAsync(IEnumerable<Guid> userIds);
        Task<CustomerForReadPrivateInfoDto> GetCustomerInfoByUserIdAsync(Guid userId, bool trackChanges);
        Task<CustomerForReadMinimizedDto> GetMinimizedCustomerInfoByUserIdAsync(Guid userId, bool trackChanges);
        Task<CustomerForReadPublicInfoDto> GetCustomerByTagAsync(string tag, bool trackChanges);
        Task UpdateCustomerAsync(Guid userId, CustomerForUpdateDto customerDto);
        Task DeleteCustomerByUserIdAsync(Guid userId);
    }
}
