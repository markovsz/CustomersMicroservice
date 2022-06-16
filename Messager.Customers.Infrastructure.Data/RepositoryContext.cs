using Messager.Customers.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Customers.Infrastructure.Data
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public RepositoryContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
