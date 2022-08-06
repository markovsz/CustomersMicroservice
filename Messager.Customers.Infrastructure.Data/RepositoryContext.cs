using Messager.Customers.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Messager.Customers.Infrastructure.Data
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}
