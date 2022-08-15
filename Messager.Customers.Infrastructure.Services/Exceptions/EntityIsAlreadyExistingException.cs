using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Infrastructure.Services.Exceptions
{
    public class EntityIsAlreadyExistingException<TEntity> : Exception
    {
        public EntityIsAlreadyExistingException()
            : base($"{nameof(TEntity)} with such id is already existing")
        {
        }
    }
}
