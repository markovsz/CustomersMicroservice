using Messager.Customers.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;

namespace Messager.Customers.Infrastructure.Data.Configurations
{
    public class IconConfiguration : IEntityTypeConfiguration<Icon>
    {
        private IConfiguration _configuration;

        public IconConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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
