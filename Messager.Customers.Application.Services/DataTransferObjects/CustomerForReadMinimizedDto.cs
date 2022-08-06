using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Application.Services.DataTransferObjects
{
    public class CustomerForReadMinimizedDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
