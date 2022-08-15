using System;

namespace Messager.Customers.Infrastructure.Services.Exceptions
{
    public class EntityValidationFailedException<TEntity> : Exception
    {
        public EntityValidationFailedException()
            : base($"{typeof(TEntity)} validation exception")
        {
        }
    }
}
