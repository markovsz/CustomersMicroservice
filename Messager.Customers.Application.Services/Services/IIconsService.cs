using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Application.Services.Services
{
    public interface IIconsService
    {
        Task<string> GetIconAsync(Guid iconId);
        Task<Guid> PostIconAsync(string iconBase64);
    }
}
