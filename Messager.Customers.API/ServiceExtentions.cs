using Messager.Customers.Domain.Interfaces.Repositories.AdministratorSubsystem;
using Messager.Customers.Domain.Interfaces.Repositories.CustomerSubsystem;
using Messager.Customers.Domain.Interfaces.Repositories.IGuestSubsystem;
using Messager.Customers.Infrastructure.Data;
using Messager.Customers.Infrastructure.Data.Repositories.AdministratorSubsystem;
using Messager.Customers.Infrastructure.Data.Repositories.CustomerSubsystem;
using Messager.Customers.Infrastructure.Data.Repositories.GuestSubsystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messager.Customers.API
{
    public static class ServiceExtentions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("Messager_Customers")));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdministratorManager, AdministratorManager>();
            services.AddScoped<ICustomersRepositoryForAdministrator, CustomersRepositoryForAdministrator>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<ICustomersRepositoryForCustomer, CustomersRepositoryForCustomer>();
            services.AddScoped<IGuestManager, GuestManager>();
            services.AddScoped<ICustomersRepositoryForGuest, CustomersRepositoryForGuest>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAdministratorManager, AdministratorManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IGuestManager, GuestManager>();
        }
    }
}
