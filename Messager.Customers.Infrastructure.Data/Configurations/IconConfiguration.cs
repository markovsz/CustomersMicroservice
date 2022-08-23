using Messager.Customers.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messager.Customers.Infrastructure.Data.Configurations
{
    public class IconConfiguration : IEntityTypeConfiguration<Icon>
    {
        public void Configure(EntityTypeBuilder<Icon> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
