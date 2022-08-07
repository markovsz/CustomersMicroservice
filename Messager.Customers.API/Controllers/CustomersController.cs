using Messager.Customers.API.Filters;
using Messager.Customers.Application.Services.DataTransferObjects;
using Messager.Customers.Application.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messager.Customers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        
        public ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }


        [Authorize(Roles = "Administrator,Customer")]
        [HttpGet("all")]
        public async Task<IActionResult> GetCustomersAsync()//TODO: pagination
        {
            var customers = await _customersService.GetCustomersAsync();
            return Ok(customers);
        }


        [Authorize(Roles = "Administrator,Customer")]
        [HttpPost("min")]
        public async Task<IActionResult> GetMinimizedCustomersAsync([FromBody] IEnumerable<Guid> userIds)
        {
            var customers = await _customersService.GetMinimizedCustomersInfoByUserIdsAsync(userIds);
            return Ok(customers);
        }


        [Authorize(Roles = "Administrator,Customer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerInfoByUserIdAsync(Guid userId)
        {
            var customer = await _customersService.GetCustomerByUserIdAsync(userId, false);
            return Ok(customer);
        }


        [Authorize(Roles = "Administrator,Customer")]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpGet("", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomerInfoAsync(Guid userId)
        {
            var customer = await _customersService.GetCustomerByUserIdAsync(userId, false);
            return Ok(customer);
        }


        [Authorize(Roles = "Administrator,Customer")]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPut("")]
        public async Task<IActionResult> UpdateCustomerAsync(Guid userId, CustomerForUpdateDto customerDto)
        {
            await _customersService.UpdateCustomerAsync(userId, customerDto);
            return NoContent();
        }


        [Authorize(Roles = "Administrator")]
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateCustomerByUserIdAsync(Guid userId, CustomerForUpdateDto customerDto)
        {
            await _customersService.UpdateCustomerAsync(userId, customerDto);
            return NoContent();
        }
    }
}
