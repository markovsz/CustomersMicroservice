using Messager.Customers.API.Filters;
using Messager.Customers.Application.Services.DataTransferObjects;
using Messager.Customers.Application.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messager.Customers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatedEntitiesController : ControllerBase
    {
        public ICustomersService _customersService;

        public RelatedEntitiesController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [Authorize(Roles = "Administrator,Customer")]/*!*/
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpPost("")]
        public async Task<IActionResult> CreateCustomerAsync(Guid userId, CustomerForCreateDto customerDto)
        {
            var createdUser = await _customersService.CreateCustomerAsync(userId, customerDto);
            return CreatedAtRoute("GetCustomerProfile", createdUser);
        }

        [Authorize(Roles = "Administrator,Customer")]
        [ServiceFilter(typeof(ExtractUserIdFilter))]
        [HttpDelete("")]
        public async Task<IActionResult> DeleteRelatedToUserEntitiesAsync(Guid userId)
        {
            await _customersService.DeleteCustomerByUserIdAsync(userId);
            return NoContent();
        }
    }
}
