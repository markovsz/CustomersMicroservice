using System;

namespace Messager.Customers.Infrastructure.Services.Exceptions
{
    public class EntityDoesntExistException<TEntity> : Exception
    {
        public EntityDoesntExistException()
            : base($"{nameof(TEntity)} doesnt exist")
        {
        }
    }
}