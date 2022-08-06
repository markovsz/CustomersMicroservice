using Messager.Customers.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messager.Customers.Infrastructure.Data
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.UserId);

            /*
            builder.HasData(
                new Customer {
                    UserId = Guid.NewGuid(),
                    FirstName = "Sergei",
                    LastName = "Redfikh",
                    Patronymic = "Alexeevich",
                    BirthDate = new DateTime(2001, 7, 12),
                    PhoneNumber = "37529348102389",
                    CustomerTag = "rser"
                }
            );
            */
        }
    }
}
