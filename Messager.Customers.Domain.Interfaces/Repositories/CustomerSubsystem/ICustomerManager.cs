﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Domain.Interfaces.Repositories.CustomerSubsystem
{
    public interface ICustomerManager
    {
        ICustomersRepository Customers { get; }
        Task SaveAsync();
    }
}
