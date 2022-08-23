using Messager.Customers.Domain.Core.Models;
using Messager.Customers.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Infrastructure.Data.Repositories
{
    public class IconsRepository : RepositoryBase<Icon>, IIconsRepository
    {
        public IconsRepository(RepositoryContext context)
            : base(context)
        {
        }

        public async Task CreateIconAsync(Icon icon) => await CreateAsync(icon);

        public async Task<Icon> GetIconAsync(Guid iconId) =>
            await FindByCondition(i => i.Id.Equals(iconId), false)
            .FirstOrDefaultAsync();
    }
}
