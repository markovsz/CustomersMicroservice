using Messager.Customers.Domain.Core.Models;
using Messager.Customers.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Messager.Customers.Infrastructure.Data
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Icon> Icons { get; set; }

        private IConfiguration _configuration;

        public RepositoryContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new IconConfiguration(_configuration));
        }
    }
}
