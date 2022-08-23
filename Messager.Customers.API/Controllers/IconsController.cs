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
    public class IconsController : ControllerBase
    {
        private IIconsService _iconsService; 

        public IconsController(IIconsService iconsService)
        {
            _iconsService = iconsService;
        }

        [Authorize]
        [HttpGet("{iconId}")]
        public async Task<IActionResult> GetIcon(Guid iconId)
        {
            var icon = await _iconsService.GetIconAsync(iconId);
            return Ok(Content(icon));
        }


        [Authorize]
        [HttpPost("")]
        public async Task<IActionResult> PostIcon([FromBody] byte[] iconBytes)
        {
            var iconId = await _iconsService.PostIconAsync(iconBytes);
            return Created($"api/Icons/{iconId}", iconId);
        }
    }
}
